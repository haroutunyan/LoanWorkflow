using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class ApplicantFile : Entity
    {
        public long Id { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

        public Guid FileId { get; set; }
        public File.File File { get; set; }
    }
}
