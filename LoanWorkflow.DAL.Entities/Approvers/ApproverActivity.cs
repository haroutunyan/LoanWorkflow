using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Approvers
{
    public class ApproverActivity : Entity
    {
        public long Id { get; set; }
        public ActivityState State { get; set; }
        public string Note { get; set; }

        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }

        public long ApproverGroupId { get; set; }
        public ApproverGroup ApproverGroup { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}
