using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Enums
{
    public enum Gender
    {
        Unknown = 0,

        [Description("M")]
        Male = 1,

        [Description("F")]
        Female = 2
    }
}
