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
        public const string IN_PROGRESS = "IN_PROGRESS";
        public const string DAMAGED = "DAMAGED";
        public const string INCORRECT = "INCORRECT";
        public const string VALID = "VALID";
        public const string RETURN = "RETURN";
        public const string OUTOFSEASON = "OUTOFSEASON";
    }
}
