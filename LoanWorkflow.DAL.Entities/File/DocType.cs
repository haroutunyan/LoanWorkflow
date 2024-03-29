using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.File
{
    public class DocType : Entity
    {
        public DocumentType Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
