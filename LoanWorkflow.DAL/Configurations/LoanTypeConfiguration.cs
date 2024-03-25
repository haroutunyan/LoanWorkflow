using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class LoanTypeConfiguration : IEntityTypeConfiguration<LoanType>
    {
        public void Configure(EntityTypeBuilder<LoanType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Parent)
                .WithMany(x=>x.Childs)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.File)
                .WithOne(x=>x.LoanType)
                .HasForeignKey<LoanType>(x=>x.FileId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
