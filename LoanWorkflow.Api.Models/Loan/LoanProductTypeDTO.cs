namespace LoanWorkflow.Api.Models.Loan
{
    public class LoanProductTypeDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int TermsId { get; set; }
        public int AgrrementId { get; set; }
        public int TemplateId { get; set; }
        public List<LoanProductSettingDTO> LoanProductSettings { get; set; }
    }
}
