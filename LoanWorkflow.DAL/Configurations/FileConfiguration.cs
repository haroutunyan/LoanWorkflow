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
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Data)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.HasOne(e => e.DocType)
                .WithMany(e => e.Files)
                .HasForeignKey(e => e.DocTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
