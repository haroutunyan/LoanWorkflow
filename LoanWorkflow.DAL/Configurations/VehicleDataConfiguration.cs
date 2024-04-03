using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Configurations
{
    public class VehicleDataConfiguration : IEntityTypeConfiguration<VehicleData>
    {
        public void Configure(EntityTypeBuilder<VehicleData> builder)
        {
            builder.ToTable("Vehicles");

            builder.OwnsMany(x => x.Vehicles, m =>
            {
                m.Property(c => c.VinCode)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.RegNum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.CertNum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.OwnerCertId)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.EnginePower)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.EngineHp)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.EngineNum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.ChassisNum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.FuelType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Weight)
                    .IsRequired(false);
                m.Property(c => c.MaxWeight)
                    .IsRequired(false);
                m.Property(c => c.BodyNum)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.TemporaryNumber)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.TransitNumber)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.SpecialNotes)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Released)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.RecordingDate)
                    .IsRequired(false);
                m.Property(c => c.Inactive)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Model)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.ModelCode)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.ModelName)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Color)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.VehicleType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.VehicleTypeId)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.VehicleGroup)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.BodyType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Number)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.NumberPlateType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.IsBlocked)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.RegistrationStatus)
                    .HasMaxLength(50)
                    .IsRequired(false);

                m.OwnsMany(c => c.Lenders, l =>
                {
                    l.ToTable("Lenders");

                    l.Property(k => k.FirstName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.MiddleName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.LastName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.NationalityCountryId)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.DocumentType)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.IdentificationNumber)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Ssn)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Shares)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Currency)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.IsLegalEntity)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Place)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.AllowedLending)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.JoinedDate)
                        .HasMaxLength(50)
                        .IsRequired(false);
                });

                m.OwnsMany(c => c.Owners, l =>
                {
                    l.ToTable("VehicleOwners");

                    l.Property(k => k.FirstName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.MiddleName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.LastName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.NationalityCountryId)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.DocumentType)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.IdentificationNo)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Psn)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Shares)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.Sex)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.IsLegalEntity)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.JoinedDate)
                        .HasMaxLength(50)
                        .IsRequired(false);
                });

                m.OwnsOne(c => c.InsuranceInfo, l =>
                {
                    l.Property(k => k.InsuranceName)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.StartDate)
                        .HasMaxLength(50)
                        .IsRequired(false);
                    l.Property(k => k.EndDate)
                        .HasMaxLength(50)
                        .IsRequired(false);
                });
            });
        }
    }
}