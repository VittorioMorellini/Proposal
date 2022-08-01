using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proposal.Core.Models;
using Proposal.Core.Utils;

namespace Proposal.Core.Services
{
    public interface IProductService : IBaseService<Product, long, ProposalDbContext>
    {
        IEnumerable<Product> Search(ProductSearchModel model);
        Task<IEnumerable<ProductOperation>> GetOperations(long id);
    }

    public class ProductService : BaseService<Product, long, ProposalDbContext>, IProductService
    {
        //Dependency Injection for all the component I need
        private readonly ILogger<ProductService> logger;
        public ProductService(ILogger<ProductService> logger, ProposalDbContext ctx = null)
            : base(ctx)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Override example to customize a Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Product Find(long id)
        {
            var product = ctx.Product
                .AsSplitQuery()
                .Include(x => x.ProductOperation)
                .Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        /// <summary>
        /// Task example to return operations of the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOperation>> GetOperations(long id)
        {
            IEnumerable<ProductOperation> result = await ctx.ProductOperation.Where(x => x.ProductId == id).ToListAsync();
            return result;
        }

        /// <summary>
        /// Example of search called with a Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<Product> Search(ProductSearchModel model)
        {
            var query = ctx.Product.AsQueryable();
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Code))
                    query = query.Where(x => x.Code.StartsWith(model.Code));
                if (!string.IsNullOrWhiteSpace(model.Description))
                    query = query.Where(x => x.Description.StartsWith(model.Description));

                //Paging Server side
                query = query.ApplyPaging(model);
            }
            catch(Exception ex)
            {
                logger.LogError("Error in Search procutService", ex);
                throw;
            }
            return query.ToList();
        }
    }

    public class ProductSearchModel : QueryBuilderSearchModel
    {
        public long? ProductStateId { get; set; }
        public string? ProductState { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
