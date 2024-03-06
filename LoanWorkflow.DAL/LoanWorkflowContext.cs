using LoanWorkflow.DAL.Entities.File;
using LoanWorkflow.DAL.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL
{
    public sealed partial class LoanWorkflowContext(
        DbContextOptions<LoanWorkflowContext> options)
        : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
    {
        public DbSet<Entities.File.File> Files { get; set; }
        public DbSet<Entities.File.DocType> DocTypes { get; set; }
        
        public int SaveChanges(long initiator, bool acceptAllChangesOnSuccess)
        {
            SetAuditData(initiator);
            return SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(long initiator, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAuditData(initiator);
            return SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
