using LoanWorkflow.DAL.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Configurations
{
    public class StoredEventConfiguration : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EventType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.AggregateType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.EventData)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.AggregateId)
                .IsRequired();

            builder.Property(e => e.Version)
                .IsConcurrencyToken()
                .IsRequired();
        }
    }
}
