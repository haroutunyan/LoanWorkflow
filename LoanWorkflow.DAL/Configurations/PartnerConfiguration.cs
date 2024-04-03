using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LoanWorkflow.DAL.Entities;

namespace LoanWorkflow.DAL.Configurations
{
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100);
        }
    }
}
