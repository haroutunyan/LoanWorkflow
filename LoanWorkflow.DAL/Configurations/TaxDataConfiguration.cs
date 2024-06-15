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
    public class TaxDataConfiguration : IEntityTypeConfiguration<TaxData>
    {
        public void Configure(EntityTypeBuilder<TaxData> builder)
        {
            builder.ToTable("TaxData");

            builder.OwnsMany(e => e.TaxPayerInfo, x =>
            {
                x.ToTable("TaxPayerInfos");

                x.Property(m => m.TaxPayerId)
                    .HasMaxLength(10)
                    .IsRequired();

                x.OwnsMany(m => m.PersonInfoPeriods, l =>
                {
                    l.ToTable("PersonInfoPeriods");

                    l.Property(k => k.Date)
                        .IsRequired();

                    l.OwnsOne(k => k.PersonInfo, v =>
                    {
                        v.ToTable("PersonInfo");

                        v.Property(z => z.SalaryEquivPayments)
                            .IsRequired();
                        v.Property(z => z.SocialPaymentsPaid)
                            .IsRequired();
                        v.Property(z => z.CivilLowContractPayments)
                            .IsRequired();
                        v.Property(z => z.WorkingHours)
                            .IsRequired();
                        v.Property(z => z.Socialpayments)
                            .IsRequired();
                        v.Property(z => z.IncomeTax)
                            .IsRequired();
                    });
                });
            });
        }
    }
}
