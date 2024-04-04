using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.Users;

namespace LoanWorkflow.DAL.Entities
{
    public class Partner : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PartnerType PartnerType { get; set; }

        public long? ParentId { get; set; }
        public Partner? Parent { get; set; }

        public ICollection<Partner> Childs { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
