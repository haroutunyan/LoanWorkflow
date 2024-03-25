using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanType : Entity
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }

        public short? ParentId { get; set; }    
        public LoanType? Parent { get; set; }
        public ICollection<LoanType> Childs { get; set; }
        public ICollection<LoanProductType> LoanProductTypes { get; set; }
        public ICollection<LoanProductSetting> LoanProductSetting { get; set; }
        public ICollection<ApproverGroup> ApproverGroups { get; set; }
    }
}
