using Newtonsoft.Json.Converters;
using System.Globalization;

namespace LoanWorkflow.Core.Converters
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            Culture = CultureInfo.InvariantCulture;
            DateTimeFormat = format;
            DateTimeStyles = DateTimeStyles.AssumeUniversal;
        }

        public override bool CanConvert(Type objectType)
        {
            if (!(objectType == typeof(DateTime)))
            {
                return objectType == typeof(DateTime?);
            }

            return true;
        }
    }
}
