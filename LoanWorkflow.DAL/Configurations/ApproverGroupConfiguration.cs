using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Approvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApproverGroupConfiguration : IEntityTypeConfiguration<ApproverGroup>
    {
        public void Configure(EntityTypeBuilder<ApproverGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasOne(x => x.LoanType)
                .WithMany(x => x.ApproverGroups)
                .HasForeignKey(x => x.LoanTypeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
