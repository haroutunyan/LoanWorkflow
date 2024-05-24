namespace LoanWorkflow.Api.Models.Loan
{
    public class GetLoanTypeShortResponseModel
    {
        public short Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public List<ChildLoanTypeShortModel>? Childs { get; set; }
    }

    public class ChildLoanTypeShortModel
    {
        public short Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public bool HasPledge { get; set; }
        public string? Img { get; set; }
    }
}
