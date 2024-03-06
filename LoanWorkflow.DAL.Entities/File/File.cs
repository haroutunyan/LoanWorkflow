using LoanWorkflow.DAL.Entities.Abstractions;

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
    }
}
