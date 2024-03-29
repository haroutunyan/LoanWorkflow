using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public abstract class PersonalInfoBase : Entity
    {
        public Guid Id { get; set; }
        public PersonalInfoType PersonalInfoType { get; set; }

        public ICollection<ApplicantPersonalInfo> ApplicantPersonalInfos { get; set; }
    }
}
