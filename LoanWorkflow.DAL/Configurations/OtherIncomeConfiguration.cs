using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class OtherIncomeConfiguration : IEntityTypeConfiguration<OtherIncome>
    {
        public void Configure(EntityTypeBuilder<OtherIncome> builder)
        {
            builder.ToTable("OtherIncome");

            builder.Property(x => x.TaxpayerNumber)
            .HasMaxLength(50);

            builder.Property(x => x.CompanyName)
            .HasMaxLength(100);

            builder.Property(x => x.Address)
            .HasMaxLength(100);

            builder.Property(x => x.ActivityTypeId);

            builder.Property(x => x.ActivityPositionId);

            builder.Property(x => x.ExperienceInYear);

            builder.Property(x => x.GrossSalary);

            builder.Property(x => x.Salary);

            builder.Property(x => x.IsPreCorruption);

            builder.Property(x => x.FileId);

            builder.HasOne(x => x.ActivityType)
           .WithMany(at => at.OtherIncomes)
           .HasForeignKey(x => x.ActivityTypeId);

            builder.HasOne(x => x.ActivityPosition)
            .WithMany(ap => ap.OtherIncomes)
            .HasForeignKey(x => x.ActivityPositionId);

            builder.HasOne(x => x.ActivityPosition)
            .WithMany(ap => ap.OtherIncomes)
            .HasForeignKey(x => x.ActivityPositionId);

        }
    }
}
