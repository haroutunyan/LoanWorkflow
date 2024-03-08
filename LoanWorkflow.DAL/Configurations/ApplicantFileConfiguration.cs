using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ApplicantFileConfiguration : IEntityTypeConfiguration<ApplicantFile>
    {
        public void Configure(EntityTypeBuilder<ApplicantFile> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Applicant)
                .WithMany(e => e.ApplicantFiles)
                .HasForeignKey(e => e.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.File)
                .WithMany(e => e.ApplicantFiles)
                .HasForeignKey(e => e.FileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
