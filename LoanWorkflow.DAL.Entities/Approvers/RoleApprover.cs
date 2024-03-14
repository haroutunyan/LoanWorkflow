using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Approvers
{
    public class RoleApprover : Entity
    {
        public long Id { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long ApproverGroupId { get; set; }
        public ApproverGroup ApproverGroup { get; set; }
    }
}
