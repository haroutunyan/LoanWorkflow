using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Clients
{
    public class ClientLoanApplicationRequestModel
    {
        public required string ClientSSN { get; set; }
        public int ApplicationId { get; set; }
        public short LoanType { get; set; }
        public short LoanId { get; set; }
        public short LoanProductType { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent {  get; set; }
        public required string Currency {  get; set; }
        public RepaymentType RepaymentType { get; set; }
        public required string Duration { get; set; }
        public LoanReceivingMethod ReceivingMethod { get; set; }
        public required string FileAttached1 { get; set; }
        public string? FileAttached2 { get; set; }
    }
}
