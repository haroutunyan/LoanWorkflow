using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.DAL.Entities.File;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.DAL.Entities.Loan;

namespace LoanWorkflow.DAL
{
    public sealed partial class LoanWorkflowContext(
        DbContextOptions<LoanWorkflowContext> options)
        : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
    {
        public DbSet<Entities.File.File> Files { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantFile> ApplicantFiles { get; set; }
        public DbSet<ApplicantPersonalInfo> ApplicantPersonalInfos { get; set; }
        public DbSet<AvvData> AvvData { get; set; }
        public DbSet<PersonalInfoBase> PersonalInfoBase { get; set; }
        public DbSet<DocType> DocTypes { get; set; }
        
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
