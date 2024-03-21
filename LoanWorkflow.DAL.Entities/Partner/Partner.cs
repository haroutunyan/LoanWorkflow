using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Users;

namespace LoanWorkflow.DAL.Entities
{
    public class Partner : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
