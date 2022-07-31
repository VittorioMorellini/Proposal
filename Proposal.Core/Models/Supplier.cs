using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string? Code { get; set; }
        public string BusinessName { get; set; } = null!;
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
