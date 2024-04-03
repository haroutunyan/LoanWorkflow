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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(e => e.BirthDate)
                .IsRequired();
            builder.Property(e => e.Gender)
                .IsRequired();
            builder.Property(e => e.SSN)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(e => e.Document)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(e => e.DocIssuer)
                .HasMaxLength(5)
                .IsRequired();
            builder.Property(e => e.DocIssuedDate)
                .IsRequired();
            builder.Property(e => e.DocValidityDate)
                .IsRequired();
            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.ActualAddress)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(e => e.SecondPhoneNumber)
                .HasMaxLength(15)
                .IsRequired(false);
            builder.Property(e => e.Email)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
