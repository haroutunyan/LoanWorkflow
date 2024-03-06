using FluentValidation;
using LoanWorkflow.Api.Models.File.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Validations.File
{
    public class SaveFileRequestValidator : AbstractValidator<SaveFileRequest>
    {
        public SaveFileRequestValidator()
        {
            RuleFor(e => e.File)
                //.Must(x=>x.Length < ) setup your file size
                .NotEmpty()
                .NotNull();
        }
    }
}
