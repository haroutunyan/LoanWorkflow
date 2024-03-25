using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class LoanProductSettingConfiguration : IEntityTypeConfiguration<LoanProductSetting>
    {
        public void Configure(EntityTypeBuilder<LoanProductSetting> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RepaymentType)
            .HasConversion(x => x.ToString(), m => (RepaymentType)Enum.Parse(typeof(RepaymentType), m))
            .IsRequired();


            builder.HasOne(x => x.LoanProductType)
              .WithMany(x => x.LoanProductSettings)
              .HasForeignKey(x=>x.ProductTypeId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoanSetting)
             .WithMany(x => x.LoanProductSettings)
             .HasForeignKey(x => x.SettingId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
