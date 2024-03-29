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
    public class CivilPersonConfiguration : IEntityTypeConfiguration<CivilPerson>
    {
        public void Configure(EntityTypeBuilder<CivilPerson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(v => v.Ssn)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.DocumentType)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.DocumentNumber)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.Citizenship)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.DocumentDepartment)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.DocumentIssueDate)
                .IsRequired(false);
            builder.Property(v => v.DocumentExpiryDate)
                .IsRequired(false);
            builder.Property(v => v.NewLastName)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.LastNameBeforeMarriage)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.Gender)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.EducationLevel)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.EmploymentStatus)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.MaritalStatus)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(v => v.MarriageNumber)
                .IsRequired(false);

            builder.OwnsOne(v => v.Birth, n =>
            {
                n.Property(c => c.Country)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Region)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Community)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            builder.OwnsOne(v => v.Resident, n =>
            {
                n.ToTable("ECivilResident");

                n.Property(c => c.Country)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Region)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Community)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Residence)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Street)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.HouseType)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.House)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Apartment)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Department)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.StartDate)
                    .IsRequired(false);
                n.Property(c => c.EndDate)
                    .IsRequired(false);
            });

            builder.OwnsOne(v => v.BaseInfo, n =>
            {
                n.Property(c => c.LastName)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.FathersName)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.BirthDate)
                    .HasMaxLength(50)
                    .IsRequired(false);
                n.Property(c => c.Nationality)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });
        }
    }
}
