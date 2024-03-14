using LoanWorkflow.DAL.Entities.Pledge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class PledgeFileConfiguration : IEntityTypeConfiguration<PledgeFile>
    {
        public void Configure(EntityTypeBuilder<PledgeFile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Pledge)
                .WithMany(x=>x.Files)
                .HasForeignKey(x=>x.PledgId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.File)
                .WithMany(x => x.PledgeFiles)
                .HasForeignKey(x => x.FileId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
