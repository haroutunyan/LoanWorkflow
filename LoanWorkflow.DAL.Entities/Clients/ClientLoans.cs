using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;

namespace LoanWorkflow.DAL.Entities.Clients
{
    public class ClientLoans : Entity
    {
        public int Id { get; set; }
        public required string ClientSSN { get; set; }
        public int ApplicationId { get; set; }
        public short LoanTypeId { get; set; }
        public short LoanId { get; set; }
        public short LoanProductTypeId { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent {  get; set; }
        public required string Currency {  get; set; }
        public RepaymentType RepaymentType { get; set; }
        public string? Duration { get; set; }
        public LoanReceivingMethod ReceivingMethod { get; set; }
        public string? AttachedFile1 { get; set; }
        public string? AttachedFile2 { get; set; }

        public Client? Client { get; set; }
        public LoanType? LoanType { get; set; }
        public LoanProductType? LoanProductType { get; set; }
    }
}
