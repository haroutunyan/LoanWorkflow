using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics.Metrics;

namespace LoanWorkflow.DAL.Configurations
{
    public class DocTypeConfiguration : IEntityTypeConfiguration<DocType>
    {
        public void Configure(EntityTypeBuilder<DocType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(50);

            builder.HasData(
                 new DocType { Id = DocumentType.IdCard, Name = "Նույնականացման քարտ", Description = "Նույնականացման քարտ" },
                 new DocType { Id = DocumentType.Passport, Name = "Անձնագիր", Description = "Անձնագիր" },
                 new DocType { Id = DocumentType.SocialCard, Name = "Սոց․ քարտ", Description = "Սոցիալական քարտ" },
                 new DocType { Id = DocumentType.Hamadzynagir, Name = "Համաձայնագիր", Description = "Համաձայնագիր ԱՔՌԱ,ՆՈՐՔ , ԷԿԵՆԳ հարցումների համար" },
                 new DocType { Id = DocumentType.DimumHayt, Name = "Դիմում-Հայտ", Description = "Դիմում-Հայտ" },
                 new DocType { Id = DocumentType.TexekanqEkamtiMasin, Name = "Տեղեկանք եկամտի մասին", Description = "Տեղեկանք եկամտի մասին" },
                 new DocType { Id = DocumentType.AmusnutyanVkayakan, Name = "Ամուսնության վկայական", Description = "Ամուսնության վկայական" },
                 new DocType { Id = DocumentType.MiasnakanTexekanq, Name = "Միասնական տեղեկանք", Description = "Միասնական տեղեկանք" },
                 new DocType { Id = DocumentType.GraviVkayakan, Name = "Գրավի վկայական", Description = "Գրավի վկայական" },
                 new DocType { Id = DocumentType.Ayl, Name = "Այլ", Description = "Այլ" });
        }
    }
}
