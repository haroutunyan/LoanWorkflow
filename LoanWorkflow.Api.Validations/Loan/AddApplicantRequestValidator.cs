using FluentValidation;
using LoanWorkflow.Api.Models.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Validations.Loan
{
    public class AddApplicantRequestValidator : AbstractValidator<AddApplicantRequest>
    {
        public AddApplicantRequestValidator()
        {
            RuleFor(e => e.Type)
                .NotEmpty()
                .NotNull();
        }
    }
}
