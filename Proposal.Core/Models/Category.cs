using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Product> Product { get; set; }
    }
}
