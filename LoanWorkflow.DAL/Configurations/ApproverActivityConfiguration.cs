using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Approvers;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApproverActivityConfiguration : IEntityTypeConfiguration<ApproverActivity>
    {
        public void Configure(EntityTypeBuilder<ApproverActivity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.State)
                .HasConversion(x => x.ToString(), m => (ActivityState)Enum.Parse(typeof(ActivityState), m))
                .IsRequired();

            builder.Property(x => x.Note)
                .HasMaxLength(250);

            builder.HasOne(x => x.Application)
                .WithMany(x=>x.ApproverActivities)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ApproverGroup)
                .WithMany(x => x.ApproverActivities)
                .HasForeignKey(x => x.ApproverGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.ApproverActivities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
