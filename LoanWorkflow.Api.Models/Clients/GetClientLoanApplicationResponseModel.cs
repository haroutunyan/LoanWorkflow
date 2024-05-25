using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Clients
{
    public class GetClientLoanApplicationResponseModel
    {
        public int LoanType { get; set; }
        public int LoanId { get; set; }
        public int LoanProductType { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent {  get; set; }
        public required string Currency {  get; set; }
        public RepaymentType RepaymentType { get; set; }
        public string? Duration { get; set; }
        public LoanReceivingMethod ReceivingMethod { get; set; }
    }
}
