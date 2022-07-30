using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductStoreMovement
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long StoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime MoveDate { get; set; }
        /// <summary>
        /// is not null if this is a return form a customer
        /// </summary>
        public long? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}
