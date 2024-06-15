using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Options
{
    public record AcraCredentials
    {
        public required string UserName { get; set; }
        public required string ReqID { get; set; }
        public required string Password { get; set; }
        public required string AppNumber { get; set; }
    }
}
