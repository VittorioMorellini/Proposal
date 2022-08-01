using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Proposal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proposal.Core.Utils;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Proposal.Core.Services
{
    public interface IWarehouseService : IBaseService<Warehouse, long, ProposalDbContext>
    {
		IEnumerable<WarehouseBalance> GetBalance(WarehouseSearchModel model);

    }

    public class WarehouseService : BaseService<Warehouse, long, ProposalDbContext>, IWarehouseService
    {
        private readonly ILogger<WarehouseService> logger;
        public WarehouseService(ILogger<WarehouseService> logger, ProposalDbContext ctx = null)
            : base(ctx)
        {
            this.logger = logger;
        }

		/// <summary>
		/// Example a service to calculate warehouse balance to show in reports
		///		Service that uses directly SQL
		/// </summary>
		/// <param name="model"></param>
		/// <returns>List of warehouse balance</returns>
        public IEnumerable<WarehouseBalance> GetBalance(WarehouseSearchModel model)
        {
            List<WarehouseBalance> result = new List<WarehouseBalance>();
			List<SqlParameter> parameters = new List<SqlParameter>();
			var conn = ctx.Database.GetDbConnection();
			string sqlSelect = string.Empty;
			
			var query = ctx.Warehouse.AsQueryable();

            if (model.Id.HasValue)
                query = query.Where(x => x.Id == model.Id);
            if (!string.IsNullOrWhiteSpace(model.Description))
                query = query.Where(x => x.Description.Contains(model.Description));

            List<Warehouse> wares = query.ToList();
			try
			{
				conn.Open();
				foreach (var warehouse in wares)
				{
					DbDataReader drProducts;
					Int64 warehouseId = warehouse.Id;
					parameters.Clear();
					//Get all product related to warehouses
					sqlSelect = @" 
							SELECT DISTINCT
							Product.Description, Product.Code, 
							Product.Id
							FROM Location L 
							INNER JOIN WarehouseMovement WM ON WM.LocationTo = L.Id
							INNER JOIN Product ON Product.Id = WM.ProductId
							WHERE 1=1 
							AND L.WarehouseId = @warehouseid";

					parameters.Add(new SqlParameter("warehouseid", warehouseId));
					if (model.ProductId.HasValue)
					{
						sqlSelect += " AND WM.ProductId = @productid";
						parameters.Add(new SqlParameter("productid", model.ProductId));
					}
					//This filter value is mandatory
					sqlSelect += " AND WM.MovementDate <= @dateto";
					parameters.Add(new SqlParameter("dateto", model.DateTo));

					DbCommand command = conn.CreateCommand();
					command.Parameters.AddRange(parameters.ToArray());
					command.CommandText = sqlSelect;
					drProducts = command.ExecuteReader();
					//cycle products
					while (drProducts.Read())
					{
						parameters.Clear();
						WarehouseBalance balance = new WarehouseBalance();
						balance.Id = warehouseId;
						balance.Description = drProducts.GetString("description");
						balance.DateTo = model.DateTo;
						balance.Product = new Product();
						balance.Product.Id = drProducts.GetInt64("Id");
						balance.Product.Description = drProducts.GetString("Description");

						balance.Charge = 0; //TODO GetWarehouseLoad(Id); for locationTo

						//Query to load Sum Quantity OUT from Order
						sqlSelect = @" 
								SELECT 
								OrderDetail.ProductId, Customer.Lastname,
								SUM(OrderDetail.Quantity) AS QuantityOut, 0 AS QuantityIN 
								FROM OrderDetail
								INNER JOIN Order ON Order.Id = OrderDetail.OrderId
								INNER JOIN WarehouseMovement WM ON WM.ProductId = OrderDetail.ProductId
								INNER JOIN Location L ON WM.LocationFrom = L.Id
								LEFT OUTER JOIN Customer ON Order.CustomerId = Customer.Id
								INNER JOIN Product ON Product.Id = OrderDetail.ProductId
								WHERE 1=1
								AND L.WarehouseId = @warehouseid
								AND Order.Date <= @dateto
								AND OrderDetail.ProductId = @productid
								GROUP BY OrderDetail.ProductId, Customer.LastName
								
								--obligations and what is takeoff from locations
								UNION ALL
								SELECT
								Product.ProductId, Customer.LastName,
								SUM(WM.Quantity) AS QuantityOut, 0 AS QuantityIN 
								FROM WarehouseMovement WM
								INNER JOIN Location L ON WM.LocationFrom = Location.Id
								INNER JOIN Product ON Product.Id = L.ProductId
								LEFT OUTER JOIN Customer ON WarehouseMovement.CustomerId = Customer.Id
								WHERE 1=1
								AND L.WarehouseId = @warehouseid
								AND WM.MovementDate <= @dateto
								AND Product.Id = @productid
								GROUP BY Product.Id, Customer.Lastname
								";

						parameters.Clear();
						parameters.Add(new SqlParameter("productid", balance.Product.Id));
						parameters.Add(new SqlParameter("warehouseid", warehouseId));
						parameters.Add(new SqlParameter("dateto", model.DateTo));

						command = conn.CreateCommand();
						command.Parameters.AddRange(parameters.ToArray());
						command.CommandText = sqlSelect;
						DbDataReader drSaldi = command.ExecuteReader();
						//Int32 balance = 0;
						if (drSaldi != null && drSaldi.HasRows)
						{
							Int32 netValue = 0;
							Int32 QuantityIN = 0;
							Int32 QuantityOUT = 0;
							balance.Customer = drSaldi.GetString("Lastname");
							/*
							balance.Charge = QuantityIN;
							*/
							balance.OrderObligation = QuantityOUT; 
							netValue = QuantityIN - QuantityOUT;
							balance.Balance = netValue;
						}

						result.Add(balance);
					}
				}

				//Paging Server side
				query = query.ApplyPaging(model);
			}
			catch(Exception ex)
            {
				logger.LogError("Error in calculating balance", ex);
				throw;
            }
			finally
            {
				conn.Close();
			}
			return result;
        }

        
    }

    public class WarehouseSearchModel : QueryBuilderSearchModel
    {
        public long? Id { get; set; }
        public string? Description { get; set; }
        public long? ProductId { get; set; }
        public long? CategoryId { get; set; }
		public DateTime DateTo { get; set; }
    }

}