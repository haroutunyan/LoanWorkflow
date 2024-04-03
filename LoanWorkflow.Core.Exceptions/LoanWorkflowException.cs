using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Exceptions
{
    public class LoanWorkflowException : Exception
    {
        public LoanWorkflowException() : base() { }
        public LoanWorkflowException(string message) : base(message) { }
        public LoanWorkflowException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
