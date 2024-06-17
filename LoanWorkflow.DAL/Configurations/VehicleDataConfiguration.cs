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
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.RegNum)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.CertNum)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.OwnerCertId)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.EnginePower)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.EngineHp)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.EngineNum)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.ChassisNum)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.FuelType)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.Weight)
                    .IsRequired(false);
                m.Property(c => c.MaxWeight)
                    .IsRequired(false);
                m.Property(c => c.BodyNum)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.TemporaryNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.TransitNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.SpecialNotes)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.Released)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.RecordingDate)
                    .IsRequired(false);
                m.Property(c => c.Inactive)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.Model)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.ModelCode)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.ModelName)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.Color)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.VehicleType)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.VehicleTypeId)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.VehicleGroup)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.BodyType)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.Number)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.NumberPlateType)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.IsBlocked)
                    .HasMaxLength(250)
                    .IsRequired(false);
                m.Property(c => c.RegistrationStatus)
                    .HasMaxLength(250)
                    .IsRequired(false);

                m.OwnsMany(c => c.Lenders, l =>
                {
                    l.ToTable("Lenders");

                    l.Property(k => k.FirstName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.MiddleName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.LastName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.NationalityCountryId)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.DocumentType)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.IdentificationNumber)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Ssn)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Shares)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Currency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.IsLegalEntity)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Place)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.AllowedLending)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.JoinedDate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                m.OwnsMany(c => c.Owners, l =>
                {
                    l.ToTable("VehicleOwners");

                    l.Property(k => k.FirstName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.MiddleName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.LastName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.NationalityCountryId)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.DocumentType)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.IdentificationNo)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Psn)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Shares)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.Sex)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.IsLegalEntity)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.JoinedDate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                m.OwnsOne(c => c.InsuranceInfo, l =>
                {
                    l.Property(k => k.InsuranceName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.StartDate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    l.Property(k => k.EndDate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });
            });
        }
    }
}