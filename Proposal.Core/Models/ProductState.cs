using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductState
    {
        public ProductState()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Product> Product { get; set; }
    }
}
