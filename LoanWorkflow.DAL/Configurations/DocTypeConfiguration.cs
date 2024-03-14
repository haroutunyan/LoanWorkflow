using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics.Metrics;

namespace LoanWorkflow.DAL.Configurations
{
    public class DocTypeConfiguration : IEntityTypeConfiguration<Entities.File.DocType>
    {
        public void Configure(EntityTypeBuilder<DocType> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(50);

            builder.HasData(
                 new DocType { Id = DocumentType.IdCard, Name = "Նույնականացման քարտ", Description = "Նույնականացման քարտ" },
                 new DocType { Id = DocumentType.Passport, Name = "Անձնագիր", Description = "Անձնագիր" },
                 new DocType { Id = DocumentType.SocialCard, Name = "Սոց․ քարտ", Description = "Սոցիալական քարտ" });
        }
    }
}
