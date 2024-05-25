using FluentValidation;
using LoanWorkflow.Api.Models.Clients;

namespace LoanWorkflow.Api.Validations.Client
{
    public class GetClientLoanApplicationValidator : AbstractValidator<GetClientLoanApplicationRequestModel>
    {
        public GetClientLoanApplicationValidator()
        {
            RuleFor(p => p.SSN).NotEmpty();
            RuleFor(p => p.ApplicationId).NotEmpty();
        }
    }
}
