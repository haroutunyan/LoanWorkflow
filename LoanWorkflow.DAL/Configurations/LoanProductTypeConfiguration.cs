using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class LoanProductTypeConfiguration : IEntityTypeConfiguration<LoanProductType>
    {
        public void Configure(EntityTypeBuilder<LoanProductType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(250);

            builder.HasOne(x => x.LoanType)
              .WithMany(x => x.LoanProductTypes)
              .HasForeignKey(x => x.LoanTypeId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
