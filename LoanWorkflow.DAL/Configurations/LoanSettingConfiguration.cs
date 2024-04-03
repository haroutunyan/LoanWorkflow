using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class LoanSettingConfiguration : IEntityTypeConfiguration<LoanSetting>
    {
        public void Configure(EntityTypeBuilder<LoanSetting> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Currency)
                .HasMaxLength(4);

            builder.Property(x => x.DateRangeType)
                .HasConversion(x => x.ToString(), m => (DateRangeType)Enum.Parse(typeof(DateRangeType), m))
                .IsRequired();

            builder.Property(x => x.CommissionChargeType)
               .HasConversion(x => x.ToString(), m => (CommissionChargeType)Enum.Parse(typeof(CommissionChargeType), m))
               .IsRequired();

            builder.Property(x => x.RepaymentChargeType)
               .HasConversion(x => x.ToString(), m => (RepaymentChargeType)Enum.Parse(typeof(RepaymentChargeType), m))
               .IsRequired();


            builder.Property(x => x.LoanProvidingType)
               .HasConversion(x => x.ToString(), m => (LoanProvidingType)Enum.Parse(typeof(LoanProvidingType), m))
               .IsRequired();

        }
    }
}
  
