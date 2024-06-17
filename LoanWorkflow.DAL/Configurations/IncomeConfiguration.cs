using LoanWorkflow.DAL.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Configurations
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(x => x.Sphere)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Position)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Experience)                
                .IsRequired();
            builder.Property(x => x.GrossIncome)                
                .IsRequired();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Incomes)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
