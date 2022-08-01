using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proposal.Core.Models
{
    public class WarehouseBalance
    {
        [NotMapped]
        public long Id { get; set; }
        [NotMapped]
        public string? Description { get; set; }
        [NotMapped]
        public int Charge { get; set; }
        public int OrderObligation { get; set; }
        public int Balance { get; set; }
        [NotMapped]
        public Product? Product { get; set; }
        [NotMapped]
        public DateTime DateTo { get; set; }
        [NotMapped]
        public string? Customer { get; set; }

    }
}
