using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class MovableEstateTypeConfiguration : IEntityTypeConfiguration<Entities.Pledge.MovableEstateType>
    {
        public void Configure(EntityTypeBuilder<Entities.Pledge.MovableEstateType> builder)
        {
            builder.HasKey(x => x.Type);

            
            builder.Property(x => x.Type)
               .ValueGeneratedNever()
               .HasConversion(x => x.ToString(), m => (Core.Enums.MovableEstateType)Enum.Parse(typeof(Core.Enums.MovableEstateType), m))
               .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
