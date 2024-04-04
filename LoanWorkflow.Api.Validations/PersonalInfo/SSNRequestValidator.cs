using FluentValidation;
using LoanWorkflow.Api.Models.Personallnfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Validations.PersonalInfo
{
    public class SSNRequestValidator : AbstractValidator<SSNRequest>
    {
        public SSNRequestValidator()
        {
            RuleFor(x => x.SSN)
                .NotEmpty()
                .NotNull()
                .Length(10);
        }
    }
}
