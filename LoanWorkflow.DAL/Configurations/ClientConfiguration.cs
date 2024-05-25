using LoanWorkflow.DAL.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasAlternateKey(p => p.SSN);
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
                .HasMaxLength(50);
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(e => e.SecondPhoneNumber)
                .HasMaxLength(15);
            builder.Property(e => e.Email)
                .IsRequired();
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.ConnectionType)
                .HasMaxLength(20);
            builder.Property(e => e.BorrowerSSN)
                .HasMaxLength(10);

            builder.HasMany(c => c.ClientLoans)
                .WithOne(o => o.Client)
                .HasForeignKey(l => l.ClientSSN)
                .HasPrincipalKey(c => c.SSN);
        }
    }
}
