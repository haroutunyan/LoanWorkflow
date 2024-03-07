using LoanWorkflow.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Helpers
{
    public static class HelperMethods
    {
        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs<T>(T model)
        {
            var keyValuePairs = new List<KeyValuePair<string, string>>();
            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);
                foreach (var attribute in attributes)
                {
                    var formUrlAttribute = attribute as FormUrlNameAttribute;
                    if (formUrlAttribute is not null)
                    {
                        var value = property.GetValue(model);
                        if (value is not null)
                            keyValuePairs.Add(new KeyValuePair<string, string>(formUrlAttribute.PropertyName, value.ToString()));
                    }
                }
            }

            return keyValuePairs;
        }
    }
}