namespace LoanWorkflow.Api.Models.Loan
{
    public class LoanTypesResponse
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public List<ChildLoanTypesDTO> Childs { get; set; }
    }
}
