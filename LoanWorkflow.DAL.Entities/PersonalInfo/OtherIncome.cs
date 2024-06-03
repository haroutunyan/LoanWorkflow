using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.File;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class OtherIncome : PersonalInfoBase
    {
        public OtherIncome()
            => PersonalInfoType = PersonalInfoType.OtherIncome;

        public string TaxpayerNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int ActivityTypeId { get; set; }
        public int ActivityPositionId { get; set; }
        public double ExperienceInYear { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Salary { get; set; }
        public bool IsPreCorruption { get; set; }
        public Guid FileId { get; set; }

        public Activity ActivityType { get; set; }
        public Position ActivityPosition { get; set; }
        public File.File OtherIncomeFile { get; set; }

    }
}
