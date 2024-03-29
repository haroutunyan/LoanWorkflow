using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.DAL.Entities.File;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.DAL.Entities.Approvers;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.Pledge;
using LoanWorkflow.DAL.Entities;

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
        public DbSet<ApproverActivity> ApproverActivity { get; set; }
        public DbSet<ApproverGroup> ApproverGroup { get; set; }
        public DbSet<RoleApprover> RoleApprover { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<LoanProductSetting> LoanProductSetting { get; set; }
        public DbSet<LoanProductType> LoanProductType { get; set; }
        public DbSet<LoanSetting> LoanSetting { get; set; }
        public DbSet<LoanType> LoanType { get; set; }
        public DbSet<MovableEstatePledge> MovableEstatePledge { get; set; }
        public DbSet<MovableEstateType> MovableEstateType { get; set; }
        public DbSet<PledgeBase> PledgeBase { get; set; }
        public DbSet<PledgeFile> PledgeFile { get; set; }
        public DbSet<RealEstatePledge> RealEstatePledge { get; set; }
        public DbSet<RealEstateType> RealEstateType { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<CivilPerson> CivilPersons { get; set; }
        public DbSet<ECivilData> ECivilData { get; set; }

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
