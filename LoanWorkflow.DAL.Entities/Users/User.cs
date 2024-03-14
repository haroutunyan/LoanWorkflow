using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;
using Microsoft.AspNetCore.Identity;

namespace LoanWorkflow.DAL.Entities.Users
{
    public class User : IdentityUser<long>, IEntity
    {
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? PasswordChangeDate { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleApprover> Approvers { get; set; }
    }
}
