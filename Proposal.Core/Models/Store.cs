using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Store
    {
        public Store()
        {
            Order = new HashSet<Order>();
            ProductStoreMovement = new HashSet<ProductStoreMovement>();
        }

        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime InsertDate { get; set; }
        public string? InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public long WarehouseId { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<ProductStoreMovement> ProductStoreMovement { get; set; }
    }
}
