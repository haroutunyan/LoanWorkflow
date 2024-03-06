using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;

namespace LoanWorkflow.DAL.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Entities.File.File>
    {
        public void Configure(EntityTypeBuilder<Entities.File.File> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(30);
            builder.Property(e => e.Data).HasMaxLength(250);
        }
    }
}
