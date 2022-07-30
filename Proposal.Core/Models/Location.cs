using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Location
    {
        public Location()
        {
            WarehouseMovement = new HashSet<WarehouseMovement>();
        }

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string BarCode { get; set; } = null!;
        public long WarehouseId { get; set; }
        public string? Description { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<WarehouseMovement> WarehouseMovement { get; set; }
    }
}
