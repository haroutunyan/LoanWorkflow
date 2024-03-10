using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Configurations;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class Applicant : Entity
    {
        public Guid Id { get; set; }
        public ClientType Type { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<ApplicantPersonalInfo> ApplicantPersonalInfos { get; set; }
        public ICollection<ApplicantFile> ApplicantFiles { get; set; }
    }
}
