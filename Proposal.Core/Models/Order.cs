using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public long StoreId { get; set; }
        public DateTime? Date { get; set; }
        public long? CustomerId { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? DeliveryCity { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
