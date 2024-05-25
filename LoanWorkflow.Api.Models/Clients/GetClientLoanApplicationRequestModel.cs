using LoanWorkflow.Api.Models.Personallnfo;

namespace LoanWorkflow.Api.Models.Clients
{
    public class GetClientLoanApplicationRequestModel : SSNRequest
    {
        public int ApplicationId { get; set; }
    }
}
