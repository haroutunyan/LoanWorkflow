using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class ECivilDataConfiguration : IEntityTypeConfiguration<ECivilData>
    {
        public void Configure(EntityTypeBuilder<ECivilData> builder)
        {
            builder.ToTable("ECivil");
            builder.Property(x => x.FullRefNumber)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(x => x.Type)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(x => x.RefNumber)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(x => x.RegistrationDate)
                .IsRequired(false);
            builder.Property(x => x.OfficeName)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(x => x.CertNum)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(x => x.CertDate)
                .IsRequired(false);
            builder.Property(x => x.TrackingId)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.OwnsOne(x => x.Child, m =>
            {
                m.ToTable("ECivilChild");

                m.Property(c => c.Ssn)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Gender)
                    .IsRequired(false);
                m.Property(c => c.BornChildrenCount)
                    .IsRequired(false);
                m.Property(c => c.ChildNumber)
                    .IsRequired(false);
                m.Property(c => c.BirthStatus)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.OwnsOne(v => v.BaseInfo, n =>
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

                m.OwnsOne(d => d.Birth, n =>
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
            });

            builder.OwnsOne(x => x.Death, m =>
            {
                m.ToTable("ECivilDeath");
                m.Property(c => c.Place)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Date)
                    .IsRequired(false);
                m.Property(c => c.Reason)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Age)
                    .HasMaxLength(50)
                    .IsRequired(false);
                m.Property(c => c.Unidentified)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            builder.HasOne(x => x.Presenter)
                .WithMany(x => x.PresenterECivils)
                .HasForeignKey(x => x.PresenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.PersonECivils)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Person2)
                .WithMany(x => x.Person2ECivils)
                .HasForeignKey(x => x.Person2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
