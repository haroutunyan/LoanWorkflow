using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LoanWorkflow.DAL.Entities;
using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.DAL.Configurations
{
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.PartnerType)
                .HasConversion(x => x.ToString(), m => (PartnerType)Enum.Parse(typeof(PartnerType), m))
                .IsRequired();

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Childs)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
