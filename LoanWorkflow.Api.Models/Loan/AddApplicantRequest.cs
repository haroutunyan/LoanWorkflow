using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Loan
{
    public class AddApplicantRequest : SSNRequest
    {
        public Guid ApplicationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientType Type { get; set; }   
    }
}
