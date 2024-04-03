using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Loan
{
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
