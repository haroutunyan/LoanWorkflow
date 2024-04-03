using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class CesDataConfiguration : IEntityTypeConfiguration<CesData>
    {
        public void Configure(EntityTypeBuilder<CesData> builder)
        {
            builder.ToTable("CesData");

            builder.OwnsMany(e => e.Inquests, x =>
            {
                x.ToTable("Inquests");

                x.Property(d => d.InquestId)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.InquestDate)
                    .IsRequired(false);
                x.Property(d => d.ClaimSum)
                    .IsRequired(false);
                x.Property(d => d.Aliment)
                    .IsRequired(false);
                x.Property(d => d.PlaintiffName)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.InquestState)
                    .IsRequired(false);
                x.Property(d => d.InquestType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.DistributionProcedure)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.ChangeDate)
                    .IsRequired(false);
                x.Property(d => d.Article)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.CourtId)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.OrderNumber)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.OrderText)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.OldOrderText)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.OrderDate)
                    .IsRequired(false);
                x.Property(d => d.RemainingSum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.RecoverSum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.CalcPersent)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.DebtorName)
                    .HasMaxLength(50)
                    .IsRequired(false);
                x.Property(d => d.DebtorAddress)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });
        }
    }
}
