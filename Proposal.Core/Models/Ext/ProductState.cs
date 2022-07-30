using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proposal.Core.Models
{
    public partial class ProductState
    {
        //sTATE OF PRODUCT
        public const string VALID = "VALID";
        public const string EXPIRED = "EXPIRED";
        public const string DAMAGED = "DAMAGED";
        public const string OUTOFSEASON = "OUTOFSEASON";
        public const string INCORRECT = "INCORRECT";
    }
}
