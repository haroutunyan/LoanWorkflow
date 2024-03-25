using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;
using Microsoft.AspNetCore.Identity;

namespace LoanWorkflow.DAL.Entities.Users
{
    public class Role : IdentityRole<long>, IEntity
    {
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleApprover> RoleApprovers { get; set; }
    }
}
