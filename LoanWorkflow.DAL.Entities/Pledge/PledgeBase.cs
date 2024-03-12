using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public abstract class PledgeBase : Entity
    {
        public Guid Id { get; set; }
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public PledgeType Type { get; set; }
    }
}
