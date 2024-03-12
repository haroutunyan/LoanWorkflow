using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanType : Entity
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public short? ParentId { get; set; }
        public ICollection<LoanProductType> LoanProductTypes { get; set; }
        public ICollection<LoanProductSetting> LoanProductSetting { get; set; }
        public LoanType Parent { get; set; }
    }
}
