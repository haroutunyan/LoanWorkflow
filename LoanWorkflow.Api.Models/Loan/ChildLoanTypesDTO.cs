namespace LoanWorkflow.Api.Models.Loan
{
    public class ChildLoanTypesDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public string Img { get; set; }
        public List<LoanProductTypeDTO> LoanProductTypes { get;set; }

    }
}
