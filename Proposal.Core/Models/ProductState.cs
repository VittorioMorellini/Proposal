using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductState
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public long? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
