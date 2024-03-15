using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), m => (ClientType)Enum.Parse(typeof(ClientType), m))
                .IsRequired();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Applicants)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Parent)
                .WithOne()
                .HasForeignKey<Applicant>(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
