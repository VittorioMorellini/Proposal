using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            WarehouseMovement = new HashSet<WarehouseMovement>();
        }

        public long Id { get; set; }
        public long SupplierId { get; set; }
        public DateTime? Date { get; set; }
        public string? Product { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<WarehouseMovement> WarehouseMovement { get; set; }
    }
}
