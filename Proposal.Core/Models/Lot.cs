using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Lot
    {
        public Lot()
        {
            ProductOperation = new HashSet<ProductOperation>();
        }

        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public long? PurchaseOrderId { get; set; }
        public string? ListOfMaterial { get; set; }

        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public virtual ICollection<ProductOperation> ProductOperation { get; set; }
    }
}
