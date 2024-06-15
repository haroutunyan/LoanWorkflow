using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class ApplicantPersonalInfo : Entity
    {
        public long Id { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public Guid PersonalInfoId { get; set; }
        public PersonalInfoBase PersonalInfo { get; set; }
    }
}
