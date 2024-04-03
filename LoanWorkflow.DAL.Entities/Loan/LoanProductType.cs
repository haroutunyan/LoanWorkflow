using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class LoanProductType : Entity
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int TermsId { get; set; }
        public int AgrrementId { get; set; }
        public int TemplateId { get; set; }

        public short LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }

        public ICollection<LoanProductSetting> LoanProductSettings { get; set; }
    }
}
