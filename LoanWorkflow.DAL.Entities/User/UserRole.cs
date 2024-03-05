using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.User
{
    public class UserRole : IdentityUserRole<long>, IEntity
    {
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
