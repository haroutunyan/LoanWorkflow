using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Configurations;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.Pledge;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class Applicant : Entity
    {
        public long Id { get; set; }
        public ClientType Type { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }

        public long? ParentId { get; set; }
        public Applicant Parent { get; set; }

        public ICollection<Application> LoanApplications { get; set; }
        public ICollection<ApplicantPersonalInfo> ApplicantPersonalInfos { get; set; }
        public ICollection<ApplicantFile> ApplicantFiles { get; set; }
        public ICollection<PledgeBase> Pledges { get; set; }
    }
}
