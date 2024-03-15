using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanSetting: Entity
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Percent { get; set; }
        public DateRangeType DateRangeType { get; set; }
        public short MinDateRange { get; set; }
        public short MaxDateRange { get; set; }
        // public decimal DepositLoanPercent {  get; set; } avandi gravi hamar
        // public decimal DepositLoanLimit { get; set; } avandi gravi hamar
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
        // public int PrivilegedMonths { get; set; }  apariki hamar minjev qani amise chmuci tokos
        public decimal PrincipalPenalty { get; set; }
        public decimal PercentPenalty { get; set; }
        public LoanProvidingType LoanProvidingType { get; set; }
        public bool IsActive { get; set; }
        public ICollection<LoanProductSetting> LoanProductSettings { get; set; }
    }
}
