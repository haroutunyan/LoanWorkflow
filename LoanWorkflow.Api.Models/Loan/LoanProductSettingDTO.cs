using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Loan
{
    public class LoanProductSettingDTO
    {
        public int Id { get; set; }
        public string AsLoanCode { get; set; }
        public RepaymentType RepaymentType { get; set; }
        public short ProductTypeId { get; set; }

        public LoanSettingDTO LoanSetting { get; set; }
    }
}
