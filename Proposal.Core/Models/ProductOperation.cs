using System;
using System.Collections.Generic;

namespace Proposal.Core.Models
{
    public partial class ProductOperation
    {
        public long Id { get; set; }
        public string State { get; set; } = null!;
        public long ProductId { get; set; }
        public DateTime DateStart { get; set; }
        public long? WarehouseId { get; set; }
        public long? StoreId { get; set; }
        /// <summary>
        /// Informations about the production Lot
        /// </summary>
        public long? LotInId { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual Lot? LotIn { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Store? Store { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
    }
}
