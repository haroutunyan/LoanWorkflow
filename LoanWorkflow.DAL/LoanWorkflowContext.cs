using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.DAL.Entities.File;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
