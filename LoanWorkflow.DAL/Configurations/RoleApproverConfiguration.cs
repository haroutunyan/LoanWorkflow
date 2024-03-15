using LoanWorkflow.DAL.Entities.Approvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class RoleApproverConfiguration : IEntityTypeConfiguration<RoleApprover>
    {
        public void Configure(EntityTypeBuilder<RoleApprover> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RoleApprovers)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ApproverGroup)
                .WithMany(x => x.Approvers)
                .HasForeignKey(x => x.ApproverGroupId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
