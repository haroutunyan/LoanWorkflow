namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class AcraData : PersonalInfoBase
    {
        public AcraData() => PersonalInfoType = Core.Enums.PersonalInfoType.Acra;
        public string ReqID { get; set; }
        public string SID { get; set; }
        public string Error { get; set; }
        public string AppNumber { get; set; }
        public DateTime? DateTime { get; set; }
        public string ReportType { get; set; }
        public Participient Participient { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class Participient
    {
        public string ThePresenceData { get; set; }
        public string KindBorrower { get; set; }
        public DateTime? FoundationDate { get; set; }
        public string Director { get; set; }
        public string ActivityScope { get; set; }
        public string RegistryNumber { get; set; }
        public string RequestTarget { get; set; }
        public string UsageRange { get; set; }
        public string ReportNumber { get; set; }
        public string FirmName { get; set; }
        public string TaxID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string IdCardNumber { get; set; }
        public string DateofBirth { get; set; }
        public string SocCardNumber { get; set; }
        public string Address { get; set; }
        public string Residence { get; set; }
        public string PersonBankruptIncome { get; set; }
        public List<TotalLiabilitiesLoan> TotalLiabilitiesLoans { get; set; }
        public List<TotalLiabilitiesLoan> TotalLiabilitiesGuarantees { get; set; }
        public string SelfInquiryQuantity30 { get; set; }
        public string SelfInquiryQuantity { get; set; }
        public List<Loans> Loans { get; set; }
        public List<Guarantee> Guarantees { get; set; }
        public CountOfLoans CountOfLoans { get; set; }
        public CountOfLoans CountOfGuarantees { get; set; }
        public string RequestQuantity30 { get; set; }
        public string RequestQuantity { get; set; }
        public List<Interrelated> Interrelated { get; set; }
        public List<Request> Requests { get; set; }
        public string ErrorDesc { get; set; }
        public string AcraId { get; set; }
    }

    public class Request
    {
        public string BankName { get; set; }
        public DateTime? DateTime { get; set; }
        public string Reason { get; set; }
        public string SubReason { get; set; }
        public string Type { get; set; }
    }

    public class Interrelated
    {
        public string DebtorNum { get; set; }
        public List<InterrelatedLoan> InterrelatedLoans { get; set; }
    }

    public class InterrelatedLoan
    {
        public string Number { get; set; }
        public DateTime? CreditStart { get; set; }
        public DateTime? LastInstallment { get; set; }
        public string ContractAmount { get; set; }
        public string AmountDue { get; set; }
        public string AmountOverdue { get; set; }
        public string OutstandingPercent { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public string Currency { get; set; }
        public string CreditClassification { get; set; }
        public string InterrelatedSourceName { get; set; }
    }

    public class CountOfLoans
    {
        public string Current { get; set; }
        public string Closed { get; set; }
        public string Total { get; set; }
    }

    public class Guarantee
    {
        public string CreditID { get; set; }
        public string SourceName { get; set; }
        public string ContractAmount { get; set; }
        public string Currency { get; set; }
        public DateTime? ActualCreditStart { get; set; }
        public DateTime? CreditStart { get; set; }
        public DateTime? GuaranteeCancellationDate { get; set; }
        public DateTime? LastInstallment { get; set; }
        public string AnnualRate { get; set; }
        public string AmountDue { get; set; }
        public DateTime? GuaranteeLastPaymentDate { get; set; }
        public string TheGuaranteeClass { get; set; }
        public string CreditStatus { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public string CreditAmount { get; set; }
        public string CreditScope { get; set; }
        public string CreditUsePlace { get; set; }
        public DateTime? IncomingDate { get; set; }
        public string CreditType { get; set; }
        public string PaymentAmount { get; set; }
        public string AmountOverdue { get; set; }
        public string OutstandingPercent { get; set; }
        public DateTime? ClassificationLastDate { get; set; }
        public string ProlongationsNum { get; set; }
        public string GuarantorAmount { get; set; }
        public string CreditNotes { get; set; }
        public string OverdueDays { get; set; }
        public string GuarantorOverdueDays { get; set; }
        public string PledgeSubject { get; set; }
        public string CollateralNotes { get; set; }
        public string CollateralAmount { get; set; }
        public string CollateralCurrency { get; set; }
        public List<Year> OutstandingDaysCount { get; set; }
    }

    public class Loans
    {
        public string CreditID { get; set; }
        public string SourceName { get; set; }
        public string Currency { get; set; }
        public DateTime? ActualCreditStart { get; set; }
        public DateTime? CreditStart { get; set; }
        public DateTime? IncomingDate { get; set; }
        public DateTime? LastInstallment { get; set; }
        public string AnnualRate { get; set; }
        public string AmountDue { get; set; }
        public string AmountOverdue { get; set; }
        public string OutstandingPercent { get; set; }
        public DateTime? LoanLastPaymentDate { get; set; }
        public string TheLoanClass { get; set; }
        public string CreditStatus { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public string ContractAmount { get; set; }
        public string CreditAmount { get; set; }
        public string CreditScope { get; set; }
        public string CreditUsePlace { get; set; }
        public string CreditType { get; set; }
        public string OverdueDays { get; set; }
        public string PaymentAmount { get; set; }
        public DateTime? ClassificationLastDate { get; set; }
        public string CreditNotes { get; set; }
        public string ProlongationsNum { get; set; }
        public string PledgeSubject { get; set; }
        public string CollateralNotes { get; set; }
        public string CollateralAmount { get; set; }
        public string CollateralCurrency { get; set; }
        public List<Year> OutstandingDaysCount { get; set; }
        public List<string> PossiblePayments { get; set; }
    }

    public class Year
    {
        public List<Month> Months { get; set; }
        public string Name { get; set; }
    }

    public class Month
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }

    public class TotalLiabilitiesLoan
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}
