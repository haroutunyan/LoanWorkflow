using FluentValidation;
using LoanWorkflow.Api.Models.Clients;

namespace LoanWorkflow.Api.Validations.Client
{
    public class ConnectedClientInfoValidator : AbstractValidator<ConnectedClientInfoRequestModel>
    {
        public ConnectedClientInfoValidator()
        {
            Include(new BorrowerInfoValidator());
            RuleFor(p => p.ConnectionType).NotEmpty();
            RuleFor(p => p.BorrowerSSN).NotEmpty();
        }
    }
}
