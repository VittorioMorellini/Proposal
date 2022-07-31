using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class WarehouseMovement
    {
        public long Id { get; set; }
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
        /// Good that is a return from customer
        /// </summary>
        public long? CustomerId { get; set; }
        public long? LocationFrom { get; set; }
        public long LocationTo { get; set; }
        public long? PurchaseOrderId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Location? LocationFromNavigation { get; set; }
        public virtual Location LocationToNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
    }
}
