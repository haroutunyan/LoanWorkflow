using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanProductSetting : Entity
    {
        public int Id { get; set; }
        public string AsLoanCode { get; set; }
        public RepaymentType RepaymentType { get; set; }
        public short ProductTypeId { get; set; }
        public LoanProductType LoanProductType { get; set; }
        public int SettingId { get; set; }
        public LoanSetting LoanSetting { get; set; }
        public ICollection<Application> LoanApplications { get; set; }
    }
}
