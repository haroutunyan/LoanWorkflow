using FluentValidation;
using LoanWorkflow.Api.Models.Clients;

namespace LoanWorkflow.Api.Validations.Client
{
    public class ClientLoanApplicationValidator : AbstractValidator<ClientLoanApplicationRequestModel>
    {
        public ClientLoanApplicationValidator()
        {
            RuleFor(p => p.ClientSSN).NotEmpty().MaximumLength(10);
            RuleFor(p => p.ApplicationId).NotEmpty();
            RuleFor(p => p.LoanType).NotEmpty();
            RuleFor(p => p.LoanId).NotEmpty();
            RuleFor(p => p.LoanProductType).NotEmpty();
            RuleFor(p => p.Amount).NotEmpty();
            RuleFor(p => p.Percent).NotEmpty();
            RuleFor(p => p.Currency).NotEmpty();
            RuleFor(p => p.RepaymentType).IsInEnum().NotEmpty();
            RuleFor(p => p.Duration).NotEmpty();
            RuleFor(p => p.ReceivingMethod).IsInEnum().NotEmpty();
            RuleFor(p => p.FileAttached1).NotEmpty();
        }
    }
}
