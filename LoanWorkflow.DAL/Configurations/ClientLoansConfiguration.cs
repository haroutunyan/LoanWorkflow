using LoanWorkflow.DAL.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ClientLoansConfiguration : IEntityTypeConfiguration<ClientLoans>
    {
        public void Configure(EntityTypeBuilder<ClientLoans> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created).HasDefaultValueSql("GetDate()");
            builder.Property(x => x.Percent).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ClientSSN).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.Currency).HasColumnType("nvarchar(3)").IsRequired();
            builder.Property(x => x.Duration).HasColumnType("nvarchar(70)").IsRequired();
            builder.HasOne(x => x.LoanType)
                .WithMany().HasForeignKey(x => x.LoanTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.LoanProductType)
                .WithMany()
                .HasForeignKey(x => x.LoanProductTypeId);
        }
    }
}
