using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class RealEstateTypeConfiguration : IEntityTypeConfiguration<Entities.Pledge.RealEstateType>
    {
        public void Configure(EntityTypeBuilder<Entities.Pledge.RealEstateType> builder)
        {
            builder.HasKey(x=>x.Type);

            builder.Property(x => x.Type)
               .ValueGeneratedNever()
               .HasConversion(x => x.ToString(), m => (Core.Enums.RealEstateType)Enum.Parse(typeof(Core.Enums.RealEstateType), m))
               .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
