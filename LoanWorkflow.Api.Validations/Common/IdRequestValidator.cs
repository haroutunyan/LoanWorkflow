using FluentValidation;
using LoanWorkflow.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Validations.Common
{
    public class IdRequestIntValidator : AbstractValidator<IdRequest<int>>
    {
        public IdRequestIntValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class IdRequestLongValidator : AbstractValidator<IdRequest<long>>
    {
        public IdRequestLongValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class IdRequestShortValidator : AbstractValidator<IdRequest<short>>
    {
        public IdRequestShortValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan((short)0);
        }
    }
}
