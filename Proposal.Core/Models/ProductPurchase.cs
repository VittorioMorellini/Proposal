using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductPurchase
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long StoreId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}
