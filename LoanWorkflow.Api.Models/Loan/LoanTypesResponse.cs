using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Loan
{
    public class LoanTypesResponse
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public List<ChildLoanTypesDTO> Childs { get; set; }
    }

    public class ChildLoanTypesDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public List<LoanProductTypeDTO> LoanProductTypes { get;set; }

    }

    public class LoanProductTypeDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int TermsId { get; set; }
        public int AgrrementId { get; set; }
        public int TemplateId { get; set; }
        public List<LoanProductSettingDTO> LoanProductSettings { get; set; }
    }

    public class LoanProductSettingDTO
    {
        public int Id { get; set; }
        public string AsLoanCode { get; set; }
        public RepaymentType RepaymentType { get; set; }
        public short ProductTypeId { get; set; }

        public LoanSettingDTO LoanSetting { get; set; }
    }

    public class LoanSettingDTO
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Percent { get; set; }
        public DateRangeType DateRangeType { get; set; }
        public short MinDateRange { get; set; }
        public short MaxDateRange { get; set; }
        public int MinSum { get; set; }
        public int MaxSum { get; set; }
        public short MinAge { get; set; }
        public short MaxAge { get; set; }
        public decimal MinActualRate { get; set; }
        public decimal MaxActualRate { get; set; }
        public decimal SumIncrementStep { get; set; }
        public int MonthIncrementStep { get; set; }
        public decimal? MinMonthlyPrincipal { get; set; }
        public decimal Commision { get; set; }
        public CommissionChargeType CommissionChargeType { get; set; }
        public RepaymentChargeType RepaymentChargeType { get; set; }
        public decimal ProvisionFeePercent { get; set; }
        public decimal ProvisionMaxPercent { get; set; }
        public decimal PrincipalPenalty { get; set; }
        public decimal PercentPenalty { get; set; }
        public LoanProvidingType LoanProvidingType { get; set; }
        public bool IsActive { get; set; }
    }
}
