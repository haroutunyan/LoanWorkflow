using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Approvers
{
    public class ApproverGroup : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte Order { get; set; }
        public bool IsRequired { get; set; }
        public decimal MaxApprovableAmount { get; set; }
        public byte ApproveCountPerRole { get; set; }
        public decimal ApproveCountByPercent { get; set; }
        public short LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }

        public ICollection<RoleApprover> Approvers { get; set; }
    }
}
