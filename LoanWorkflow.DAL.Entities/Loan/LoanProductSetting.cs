using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanProductSetting : Entity
    {
        public int Id { get; set; }
        public short ProductTypeId { get; set; }
        public short SettingId { get; set; }
        public string AsLoanCode { get; set; }
        public RepaymentType RepaymentType { get; set; }
        public LoanProductType LoanProductType { get; set; }
        public LoanSetting LoanSetting { get; set; }
    }
}
