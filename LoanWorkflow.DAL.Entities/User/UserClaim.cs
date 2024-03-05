using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LoanWorkflow.DAL.Entities.User
{
    public class UserClaim : IdentityUserClaim<long>, IEntity
    {
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
