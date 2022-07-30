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
    }

    public class ProductService : BaseService<Product, long, ProposalDbContext>, IProductService
    {
        private readonly ILogger<ProductService> logger;
        public ProductService(ILogger<ProductService> logger, ProposalDbContext ctx = null)
            : base(ctx)
        {
            this.logger = logger;
        }

        public override Product Find(long id)
        {
            var product = ctx.Product
                .Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        public IEnumerable<Product> Search(ProductSearchModel model)
        {
            var query = ctx.Product.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Code))
                query = query.Where(x => x.Code.StartsWith(model.Code));
            if (!string.IsNullOrWhiteSpace(model.Description))
                query = query.Where(x => x.Description.StartsWith(model.Description));

            return query.ToList();
        }
    }

    public class ProductSearchModel
    {
        public long? FlowId { get; set; }
        public long? CertificateId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? Disabled { get; set; }
    }
}
