using LoanWorkflow.DAL.Configurations;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Pledge;

namespace LoanWorkflow.DAL.Entities.File
{
    public class File : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public short DocTypeId { get; set; }
        public string Data { get; set; }
        public DocType DocType { get; set; }

        public ICollection<ApplicantFile> ApplicantFiles { get; set; }
        public ICollection<PledgeFile> PledgeFiles { get; set; }
    }
}
