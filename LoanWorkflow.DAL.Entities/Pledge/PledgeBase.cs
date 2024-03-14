using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.PersonalInfo;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public abstract class PledgeBase : Entity
    {
        public Guid Id { get; set; }
        public string ContractNumber { get; set; }
        public DateOnly ContractDate { get; set; }
        public PledgeType Type { get; set; }
        public string UnifiedInfoNumber { get; set; }
        public DateOnly UnifiedInfoIssueDate { get; set; }
        public string AppraisalCompany { get; set; }
        public DateOnly AppraisalDate { get; set; }

        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public ICollection<PledgeFile> Files { get; set; }
    }
}
