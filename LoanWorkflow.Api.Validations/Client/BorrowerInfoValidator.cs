using FluentValidation;
using LoanWorkflow.Api.Models.Clients;

namespace LoanWorkflow.Api.Validations.Client
{
    public class BorrowerInfoValidator : AbstractValidator<BorrowerInfoRequestModel>
    {
        public BorrowerInfoValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.SSN).MaximumLength(10).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotNull().Custom((n, context) =>
            {
                if (!long.TryParse(n, out long number))
                    context.AddFailure("Invalid phone number");
            });
            RuleFor(p => p.ClientType).NotEmpty().MaximumLength(50);
        }
    }
}
