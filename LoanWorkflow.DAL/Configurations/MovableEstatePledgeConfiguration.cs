using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Pledge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class MovableEstatePledgeConfiguration : IEntityTypeConfiguration<MovableEstatePledge>
    {
        public void Configure(EntityTypeBuilder<MovableEstatePledge> builder)
        {
            builder.Property(x => x.MovableEstateType)
               .HasConversion(x => x.ToString(), m => (Core.Enums.MovableEstateType)Enum.Parse(typeof(Core.Enums.MovableEstateType), m))
               .IsRequired();

            builder.Property(x => x.PlateNumber)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Model)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.CarCertificateNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.BodyType)
               .HasConversion(x => x.ToString(), m => (CarBodyType)Enum.Parse(typeof(CarBodyType), m))
               .IsRequired();

            builder.Property(x => x.Color)
              .HasMaxLength(10)
              .IsRequired();

        }
    }
}
