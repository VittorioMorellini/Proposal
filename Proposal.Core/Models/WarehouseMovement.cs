using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class WarehouseMovement
    {
        public long Id { get; set; }
        public long? WarehouseIdFrom { get; set; }
        public long WarehouseIdTo { get; set; }
        public DateTime? MovementDate { get; set; }
        public long ProductId { get; set; }
        public int? Quantity { get; set; }
        public string InsertUser { get; set; } = null!;
        public DateTime InsertDate { get; set; }
        public string UpdateUser { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
        public string? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? Notes { get; set; }
        /// <summary>
        /// Good that become from a supplier
        /// </summary>
        public long? SupplierId { get; set; }
        /// <summary>
        /// Good that is a return from customer
        /// </summary>
        public long? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Supplier? Supplier { get; set; }
        public virtual Warehouse? WarehouseIdFromNavigation { get; set; }
        public virtual Warehouse WarehouseIdToNavigation { get; set; } = null!;
    }
}
