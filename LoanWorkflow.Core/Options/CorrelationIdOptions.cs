using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Options
{
    public class CorrelationIdOptions
    {
        private const string DefaultHeader = "X-Correlation-ID";
        public string Header { get; set; } = "X-Correlation-ID";
        public bool IncludeInResponse { get; set; } = true;
    }
}
