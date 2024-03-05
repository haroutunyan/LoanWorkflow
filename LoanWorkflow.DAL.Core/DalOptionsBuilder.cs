using LoanWorkflow.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Core
{
    public class DalOptionsBuilder
    {
        internal bool Validate()
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new DalConnectionStringException();
            return true;
        }

        public string ConnectionString { get; set; } = null!;
    }
}
