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
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(50);

            builder.HasData(
                new DocType { Id = 1, Name = "Անձնագիր", Description = "Անձնագիր" },
                 new DocType { Id = 2, Name = "Սոց․ քարտ", Description = "Սոցիալական քարտ" },
                  new DocType { Id = 3, Name = "Նույնականացման քարտ", Description = "Նույնականացման քարտ" });
        }
    }
}
