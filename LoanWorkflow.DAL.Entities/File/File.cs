using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.File
{
    public class File : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }
        public string Data { get; set; }
    }
}
