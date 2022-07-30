using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
            ProductState = new HashSet<ProductState>();
            ProductStoreMovement = new HashSet<ProductStoreMovement>();
            WarehouseMovement = new HashSet<WarehouseMovement>();
        }

        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string Code { get; set; } = null!;
        public DateTime InsertDate { get; set; }
        public string? InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public long? CategoryId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<ProductState> ProductState { get; set; }
        public virtual ICollection<ProductStoreMovement> ProductStoreMovement { get; set; }
        public virtual ICollection<WarehouseMovement> WarehouseMovement { get; set; }
    }
}
