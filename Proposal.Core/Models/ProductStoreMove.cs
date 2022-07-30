using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductStoreMove
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime MoveDate { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}
