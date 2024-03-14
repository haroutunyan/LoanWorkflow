using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class ApplicantFile : Entity
    {
        public long Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public Guid FileId { get; set; }
        public Entities.File.File File { get; set; }
    }
}
