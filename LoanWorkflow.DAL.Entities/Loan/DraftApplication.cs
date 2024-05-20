using LoanWorkflow.DAL.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class DraftApplication : Entity
    {
        public Guid Id { get; set; }
        public long LoanProductSettingId { get; set; }
        public bool Used { get; set; }
    }
}
