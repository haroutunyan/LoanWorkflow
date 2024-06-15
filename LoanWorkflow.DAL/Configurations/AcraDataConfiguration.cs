using LoanWorkflow.DAL.Entities.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWorkflow.DAL.Configurations
{
    public class AcraDataConfiguration : IEntityTypeConfiguration<AcraData>
    {
        public void Configure(EntityTypeBuilder<AcraData> builder)
        {
            builder.ToTable("AcraData");

            builder.Property(e => e.ReqID)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.SID)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.Error)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.AppNumber)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.DateTime)
                .IsRequired(false);
            builder.Property(e => e.ReportType)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.Type)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.Response)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(e => e.ErrorDesc)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.OwnsOne(e => e.Participient, op =>
            {
                op.ToTable("Participients");

                op.Property(x => x.ThePresenceData)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.KindBorrower)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.FoundationDate)
                    .IsRequired(false);
                op.Property(x => x.Director)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.ActivityScope)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.RegistryNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.RequestTarget)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.UsageRange)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.ReportNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.FirmName)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.TaxID)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.FirstName)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.LastName)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.PassportNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.IdCardNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.DateofBirth)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.SocCardNumber)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.Address)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.Residence)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.PersonBankruptIncome)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.SelfInquiryQuantity30)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.SelfInquiryQuantity)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.RequestQuantity30)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.RequestQuantity)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.ErrorDesc)
                    .HasMaxLength(250)
                    .IsRequired(false);
                op.Property(x => x.AcraId)
                    .HasMaxLength(250)
                    .IsRequired(false);

                op.OwnsOne(x => x.CountOfLoans, kl =>
                {
                    kl.ToTable("CountOfLoans");

                    kl.Property(c => c.Total)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Current)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Closed)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                op.OwnsOne(x => x.CountOfGuarantees, kl =>
                {
                    kl.ToTable("CountOfGuarantees");

                    kl.Property(c => c.Total)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Current)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Closed)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                op.OwnsMany(x => x.TotalLiabilitiesLoans, kl =>
                {
                    kl.ToTable("TotalLiabilitiesLoans");

                    kl.Property(c => c.Currency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Amount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                op.OwnsMany(x => x.TotalLiabilitiesGuarantees, kl =>
                {
                    kl.ToTable("TotalLiabilitiesGuarantees");

                    kl.Property(c => c.Currency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Amount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });

                op.OwnsMany(x => x.Loans, kl =>
                {
                    kl.ToTable("AcraLoans");

                    kl.Property(c => c.CreditID)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.SourceName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Currency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ActualCreditStart)
                        .IsRequired(false);
                    kl.Property(c => c.CreditStart)
                        .IsRequired(false);
                    kl.Property(c => c.IncomingDate)
                        .IsRequired(false);
                    kl.Property(c => c.LastInstallment)
                        .IsRequired(false);
                    kl.Property(c => c.AnnualRate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.AmountDue)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.AmountOverdue)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OutstandingPercent)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.LoanLastPaymentDate)
                        .IsRequired(false);
                    kl.Property(c => c.TheLoanClass)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditStatus)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OutstandingDate)
                        .IsRequired(false);
                    kl.Property(c => c.ContractAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditScope)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditUsePlace)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditType)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OverdueDays)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.PaymentAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ClassificationLastDate)
                        .IsRequired(false);
                    kl.Property(c => c.CreditNotes)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ProlongationsNum)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.PledgeSubject)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralNotes)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralCurrency)
                        .HasMaxLength(250)
                        .IsRequired(false);

                    kl.OwnsMany(c => c.OutstandingDaysCount, ml =>
                    {
                        ml.ToTable("LoanOutstandingDaysCount");

                        ml.Property(v => v.Name)
                            .HasMaxLength(250)
                            .IsRequired(false);

                        ml.OwnsMany(v => v.Months);
                    });

                    //kl.OwnsMany(c => c.PossiblePayments, ml =>
                    //{
                    //    ml.ToJson();
                    //});
                });

                op.OwnsMany(x => x.Guarantees, kl =>
                {
                    kl.ToTable("AcraGuarantees");

                    kl.Property(c => c.CreditID)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.SourceName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Currency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ActualCreditStart)
                        .IsRequired(false);
                    kl.Property(c => c.CreditStart)
                        .IsRequired(false);
                    kl.Property(c => c.IncomingDate)
                        .IsRequired(false);
                    kl.Property(c => c.LastInstallment)
                        .IsRequired(false);
                    kl.Property(c => c.GuaranteeCancellationDate)
                        .IsRequired(false);
                    kl.Property(c => c.AnnualRate)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.AmountDue)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.AmountOverdue)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OutstandingPercent)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.GuaranteeLastPaymentDate)
                        .IsRequired(false);
                    kl.Property(c => c.TheGuaranteeClass)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditStatus)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OutstandingDate)
                        .IsRequired(false);
                    kl.Property(c => c.ContractAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditScope)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditUsePlace)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CreditType)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.OverdueDays)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.PaymentAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ClassificationLastDate)
                        .IsRequired(false);
                    kl.Property(c => c.CreditNotes)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.ProlongationsNum)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.PledgeSubject)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralNotes)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.CollateralCurrency)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.GuarantorOverdueDays)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.GuarantorAmount)
                        .HasMaxLength(250)
                        .IsRequired(false);

                    kl.OwnsMany(c => c.OutstandingDaysCount, ml =>
                    {
                        ml.ToTable("GuaranteeOutstandingDaysCount");

                        ml.Property(v => v.Name)
                            .HasMaxLength(250)
                            .IsRequired(false);

                        ml.OwnsMany(v => v.Months);
                    });
                });

                op.OwnsMany(x => x.Interrelated, kl =>
                {
                    kl.ToTable("Interrelated");

                    kl.Property(c => c.DebtorNum)
                        .HasMaxLength(250)
                        .IsRequired(false);

                    kl.OwnsMany(c => c.InterrelatedLoans, ml =>
                    {
                        ml.ToTable("InterrelatedLoans");

                        ml.Property(v => v.Number)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.CreditStart)
                            .IsRequired(false);
                        ml.Property(v => v.LastInstallment)
                            .IsRequired(false);
                        ml.Property(v => v.ContractAmount)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.AmountDue)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.AmountOverdue)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.OutstandingPercent)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.OutstandingDate)
                            .IsRequired(false);
                        ml.Property(v => v.Currency)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.CreditClassification)
                            .HasMaxLength(250)
                            .IsRequired(false);
                        ml.Property(v => v.InterrelatedSourceName)
                            .HasMaxLength(250)
                            .IsRequired(false);
                    });
                });

                op.OwnsMany(x => x.Requests, kl =>
                {
                    kl.ToTable("AcraRequests");

                    kl.Property(c => c.BankName)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.DateTime)
                        .IsRequired(false);
                    kl.Property(c => c.Reason)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.SubReason)
                        .HasMaxLength(250)
                        .IsRequired(false);
                    kl.Property(c => c.Type)
                        .HasMaxLength(250)
                        .IsRequired(false);
                });
            });
        }
    }
}
