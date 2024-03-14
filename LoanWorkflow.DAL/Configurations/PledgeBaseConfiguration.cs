using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Pledge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class PledgeBaseConfiguration : IEntityTypeConfiguration<PledgeBase>
    {
        public void Configure(EntityTypeBuilder<PledgeBase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContractNumber)
                .HasMaxLength(20);

            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), m => (PledgeType)Enum.Parse(typeof(PledgeType), m))
                .IsRequired();

            builder.Property(x => x.UnifiedInfoNumber)
                .HasMaxLength(25);

            builder.Property(x => x.AppraisalCompany)
                .HasMaxLength(50);

            builder.HasOne(x=>x.Applicant)
                .WithMany(x=>x.Pledges)
                .HasForeignKey(x=>x.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
