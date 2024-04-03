using LoanWorkflow.DAL.Entities.Pledge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class RealEstatePledgeConfiguration : IEntityTypeConfiguration<RealEstatePledge>
    {
        public void Configure(EntityTypeBuilder<RealEstatePledge> builder)
        {
            builder.Property(x => x.RealEstateType)
               .HasConversion(x => x.ToString(), m => (Core.Enums.RealEstateType)Enum.Parse(typeof(Core.Enums.RealEstateType), m))
               .IsRequired();

            builder.Property(x => x.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Square)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.OwnershipNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.AppraisalCompany)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.AppraisalActNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.Currency)
               .HasMaxLength(4)
               .IsRequired();

            builder.Property(x => x.PledgeCertificateNumber)
               .HasMaxLength(20)
               .IsRequired();
        }
    }


}
