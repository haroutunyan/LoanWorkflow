using LoanWorkflow.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Helpers
{
    public static class Helpers
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

        public static string ToXml<T>(T Model, out string errorMessage, string RootAttribute = null)
        {
            errorMessage = string.Empty;
            string resultString = string.Empty;
            Type type = typeof(T);

            try
            {
                var serializer = string.IsNullOrEmpty(RootAttribute) ? new XmlSerializer(type) : new XmlSerializer(type, new XmlRootAttribute(RootAttribute));
                using var textWriter = new Utf8StringWriter();
                serializer.Serialize(textWriter, Model);
                resultString = textWriter.ToString();
            }
            catch (Exception e)
            {
                errorMessage = e.InnerException is not null ? e.InnerException.Message : e.Message;
            }

            return resultString;
        }
    }
}