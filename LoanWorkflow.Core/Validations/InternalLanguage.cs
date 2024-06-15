using LoanWorkflow.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Validations
{
    public class InternalLanguage
    {
        public static string GetTranslation(string key) =>
            key switch
            {
                ValidationConstants.EmailValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),
                ValidationConstants.GreaterThanOrEqualValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),
                ValidationConstants.GreaterThanValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),
                ValidationConstants.LengthValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),
                ValidationConstants.MinimumLengthValidator => ValidationMessage.For(key).WithParam("MinLength").WithParam("TotalLength").ToString(),//"The length of '{PropertyName}' must be at least {MinLength} characters. You entered {TotalLength} characters.",
                ValidationConstants.MaximumLengthValidator => ValidationMessage.For(key).WithParam("MaxLength").WithParam("TotalLength").ToString(),//"The length of '{PropertyName}' must be {MaxLength} characters or fewer. You entered {TotalLength} characters.",
                ValidationConstants.LessThanOrEqualValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),//"'{PropertyName}' must be less than or equal to '{ComparisonValue}'.",
                ValidationConstants.LessThanValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(), //"{LessThanValidator: {ComparisonValue}}",
                ValidationConstants.NotEmptyValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' must not be empty.",
                ValidationConstants.NotEqualValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),
                ValidationConstants.NotNullValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' must not be empty.",
                ValidationConstants.PredicateValidator => ValidationMessage.For(key).ToString(),//"The specified condition was not met for '{PropertyName}'.",
                ValidationConstants.AsyncPredicateValidator => ValidationMessage.For(key).ToString(),//"The specified condition was not met for '{PropertyName}'.",
                ValidationConstants.RegularExpressionValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' is not in the correct format.",
                ValidationConstants.EqualValidator => ValidationMessage.For(key).WithParam("ComparisonValue").ToString(),//"'{PropertyName}' must be equal to '{ComparisonValue}'.",
                ValidationConstants.ExactLengthValidator => ValidationMessage.For(key).WithParam("MaxLength").WithParam("TotalLength").ToString(),//"'{PropertyName}' must be {MaxLength} characters in length. You entered {TotalLength} characters.",
                ValidationConstants.InclusiveBetweenValidator => ValidationMessage.For(key).WithParam("From").WithParam("To").WithParam("Value").ToString(),//"'{PropertyName}' must be between {From} and {To}. You entered {Value}.",
                ValidationConstants.ExclusiveBetweenValidator => ValidationMessage.For(key).WithParam("From").WithParam("To").WithParam("exclusive").WithParam("Value").ToString(),//"'{PropertyName}' must be between {From} and {To} (exclusive). You entered {Value}.",
                ValidationConstants.CreditCardValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' is not a valid credit card number.",
                ValidationConstants.ScalePrecisionValidator => ValidationMessage.For(key).WithParam("ExpectedPrecision").WithParam("ExpectedScale").WithParam("Digits").WithParam("ActualScale").ToString(),//"'{PropertyName}' must not be more than {ExpectedPrecision} digits in total, with allowance for {ExpectedScale} decimals. {Digits} digits and {ActualScale} decimals were found.",
                ValidationConstants.EmptyValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' must be empty.",
                ValidationConstants.NullValidator => ValidationMessage.For(key).ToString(),//"'{PropertyName}' must be empty.",
                ValidationConstants.EnumValidator => ValidationMessage.For(key).WithParam("PropertyValue").ToString(),//"'{PropertyName}' has a range of values which does not include '{PropertyValue}'.",
                                                                                                                      // Additional fallback messages used by clientside validation integration.
                ValidationConstants.LengthSimple => "'{PropertyName}' must be between {MinLength} and {MaxLength} characters.",
                ValidationConstants.MinimumLengthSimple => "The length of '{PropertyName}' must be at least {MinLength} characters.",
                ValidationConstants.MaximumLengthSimple => "The length of '{PropertyName}' must be {MaxLength} characters or fewer.",
                ValidationConstants.ExactLengthSimple => "'{PropertyName}' must be {MaxLength} characters in length.",
                ValidationConstants.InclusiveBetweenSimple => "'{PropertyName}' must be between {From} and {To}.",
                _ => string.Empty,
            };
    }
}
