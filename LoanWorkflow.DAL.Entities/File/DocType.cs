using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.DAL.Entities.File
{
    public class DocType
    {
        public DocumentType Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
