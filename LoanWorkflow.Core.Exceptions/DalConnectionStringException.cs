using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Exceptions
{
    public class DalConnectionStringException : LoanWorkflowException
    {
        public DalConnectionStringException() : base("ConnectionString is missing")
        {
        }
    }
}
