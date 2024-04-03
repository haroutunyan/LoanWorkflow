using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Validations
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessageOverride<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule,
            ValidationMessage message)
        {
            return rule.WithMessage(message.ToString());
        }

        public static IRuleBuilderOptions<T, TProperty> WithMessageOverride<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule,
            string message,
            Dictionary<string, string> parameters = null)
        {
            return rule.WithMessageOverride(new ValidationMessage { Name = message, Params = parameters });
        }
    }
}
