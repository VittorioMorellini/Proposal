﻿using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
