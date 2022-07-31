using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Location = new HashSet<Location>();
            ProductOperation = new HashSet<ProductOperation>();
            Store = new HashSet<Store>();
        }

        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public long? WarehouseTypeId { get; set; }
        public string? InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual WarehouseType? WarehouseType { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<ProductOperation> ProductOperation { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
