using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class Location
    {
        public Location()
        {
            WarehouseMovementLocationFromNavigation = new HashSet<WarehouseMovement>();
            WarehouseMovementLocationToNavigation = new HashSet<WarehouseMovement>();
        }

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string BarCode { get; set; } = null!;
        public long WarehouseId { get; set; }
        public string? Description { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<WarehouseMovement> WarehouseMovementLocationFromNavigation { get; set; }
        public virtual ICollection<WarehouseMovement> WarehouseMovementLocationToNavigation { get; set; }
    }
}
