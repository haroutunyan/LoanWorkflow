using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.DAL.Configurations
{
    public class AvvDataConfiguration : IEntityTypeConfiguration<AvvData>
    {
        public void Configure(EntityTypeBuilder<AvvData> builder)
        {
            builder.ToTable("AvvData");
            builder.Property(x => x.PublicServiceNumber)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(x => x.SsnIndicator)
                .IsRequired();
            builder.Property(x => x.IsDead)
                .IsRequired();
            builder.Property(x => x.DeathDate)
                .IsRequired(false);

            builder.OwnsMany(x => x.AvvDocuments, sa =>
            {
                sa.ToTable("AvvDocuments");
                sa.Property(e => e.PhotoPath)
                    .HasMaxLength(100)
                    .IsRequired(false);
                sa.Property(e => e.DocumentStatus)
                    .HasMaxLength(20)
                    .IsRequired();
                sa.Property(e => e.DocumentType)
                    .HasMaxLength(30)
                    .IsRequired();
                sa.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsRequired();
                sa.Property(e => e.OtherDocumentType)
                    .HasMaxLength(100)
                    .IsRequired(false);
                sa.Property(e => e.DocumentDepartment)
                    .HasMaxLength(5)
                    .IsRequired(false);

                sa.OwnsOne(e => e.BasicDocument, bd =>
                {
                    bd.ToTable("AvvBasicDocuments");
                    bd.Property(c => c.Code)
                        .HasMaxLength(3)
                        .IsRequired(false);
                    bd.Property(c => c.Name)
                        .HasMaxLength(30)
                        .IsRequired(false);
                    bd.Property(c => c.Number)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    bd.Property(c => c.CountryName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    bd.Property(c => c.CountryCode)
                        .HasMaxLength(3)
                        .IsRequired(false);
                    bd.Property(c => c.CountryShortName)
                        .HasMaxLength(3)
                        .IsRequired(false);
                });

                sa.OwnsOne(k => k.PassportData, pd =>
                {
                    pd.ToTable("AvvDocuments");
                    pd.Property(e => e.Type)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    pd.Property(e => e.IssuanceDate)
                        .IsRequired(false);
                    pd.Property(e => e.ValidityDate)
                        .IsRequired(false);
                    pd.Property(e => e.ForeignValidityDate)
                        .IsRequired(false);
                    pd.Property(e => e.ExtensionDate)
                        .IsRequired(false);
                    pd.Property(e => e.ExtensionDepartment)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    pd.Property(e => e.RelatedDocumentNumber)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    pd.Property(e => e.RelatedDocumentDate)
                        .IsRequired(false);
                    pd.Property(e => e.RelatedDocumentDepartment)
                        .HasMaxLength(100)
                        .IsRequired(false);
                });

                sa.OwnsOne(e => e.Person, p =>
                {
                    p.ToTable("AvvPersons");
                    p.Property(m => m.FirstName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.LastName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.PatronymicName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.BirthDate)
                        .IsRequired(false);
                    p.Property(m => m.Genus)
                        .HasMaxLength(1)
                        .IsRequired(false);
                    p.Property(m => m.EnglishLastName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.EnglishFirstName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.EnglishPatronymicName)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    p.Property(m => m.BirthRegion)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.BirthCommunity)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.BirthResidence)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.BirthAddress)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.BirthCountryName)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.BirthCountryCode)
                        .HasMaxLength(3)
                        .IsRequired(false);
                    p.Property(m => m.BirthCountryShortName)
                        .HasMaxLength(3)
                        .IsRequired(false);
                    p.Property(m => m.NationalityName)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    p.Property(m => m.NationalityCode)
                        .HasMaxLength(20)
                        .IsRequired(false);

                    p.OwnsMany(m => m.Citizenships, l =>
                    {
                        l.ToTable("AvvCitizenships");
                        l.Property(k => k.CountryName)
                            .HasMaxLength(100)
                            .IsRequired(false);
                        l.Property(k => k.CitizenshipStoppedDate)
                            .IsRequired(false);
                        l.Property(k => k.CountryCode)
                            .HasMaxLength(3)
                            .IsRequired(false);
                        l.Property(k => k.CountryShortName)
                            .HasMaxLength(100)
                            .IsRequired(false);
                    });
                });
            });

            builder.OwnsMany(x => x.AvvAddresses, sa =>
            {
                sa.ToTable("AvvAddresses");
                sa.OwnsOne(m => m.ResidenceDocument, e =>
                {
                    e.ToTable("AvvResidenceDocuments");
                    e.Property(l => l.DocumentType)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    e.Property(l => l.DocumentNumber)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    e.Property(l => l.DocumentDepartment)
                        .HasMaxLength(100)
                        .IsRequired(false);
                    e.Property(l => l.ResidenceDocumentDate)
                        .IsRequired(false);
                    e.Property(l => l.DocumentValidityDate)
                        .HasMaxLength(100)
                        .IsRequired(false);
                });

                sa.OwnsOne(m => m.RegistrationAddress, e =>
                {
                    e.ToTable("AvvRegistrationAddresses");
                    e.Property(l => l.LocationCode)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.PostalIndex)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.Region)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    e.Property(l => l.Community)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    e.Property(l => l.Residence)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    e.Property(l => l.Street)
                        .HasMaxLength(20)
                        .IsRequired(false);
                    e.Property(l => l.Building)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.BuildingType)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.Apartment)
                        .HasMaxLength(10)
                        .IsRequired(false);
                });

                sa.OwnsOne(m => m.RegistrationData, e =>
                {
                    e.ToTable("AvvRegistrationData");
                    e.Property(l => l.RegistrationDepartment)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.RegistrationDate)
                        .IsRequired(false);
                    e.Property(l => l.RegistrationType)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.RegistrationStatus)
                        .HasMaxLength(10)
                        .IsRequired(false);
                    e.Property(l => l.TemporaryRegistrationDate)
                        .IsRequired(false);
                    e.Property(l => l.RegisteredDate)
                        .IsRequired(false);
                    e.Property(l => l.RegisteredDepartment)
                        .HasMaxLength(10)
                        .IsRequired(false);
                });
            });
        }
    }
}
