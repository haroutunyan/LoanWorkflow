using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.State)
            .HasConversion(x => x.ToString(), m => (LoanState)Enum.Parse(typeof(LoanState), m))
            .IsRequired();

            builder.Property(x => x.IsExpired)
                .IsRequired();

            builder.Property(x => x.DateRangeType)
           .HasConversion(x => x.ToString(), m => (DateRangeType)Enum.Parse(typeof(DateRangeType), m))
           .IsRequired();

            builder.Property(x => x.CommunicationType)
           .HasConversion(x => x.ToString(), m => (CommunicationType)Enum.Parse(typeof(CommunicationType), m))
           .IsRequired();


            builder.HasOne(x => x.LoanProductSetting)
                .WithMany(x => x.LoanApplications)
                .HasForeignKey(x => x.LoanProductSettingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Applicant)
                .WithMany(x => x.LoanApplications)
                .HasForeignKey(x => x.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
