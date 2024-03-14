using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Enums
{
    public enum LoanState
    {
        New = 0,
        Draft = 1,
        ScoreApproved = 2,
        ScoreReject = 3,
        Pending = 4,
        Approved = 5,
        Rejected = 6
    }
}
