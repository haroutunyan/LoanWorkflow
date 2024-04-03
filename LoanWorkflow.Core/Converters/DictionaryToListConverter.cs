using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Converters
{
    public class DictionaryToListConverter<TKey, TValue> : JsonConverter
    {
        private class DictionaryDTO : Dictionary<TKey, TValue>
        {
            public DictionaryDTO(KeyValuePair<TKey, TValue> pair)
                : base(1)
            {
                Add(pair.Key, pair.Value);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            if (typeof(IDictionary<TKey, TValue>).IsAssignableFrom(objectType))
            {
                return objectType != typeof(DictionaryDTO);
            }

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JToken jToken = JToken.Load(reader);
            IDictionary<TKey, TValue> dictionary = (existingValue as IDictionary<TKey, TValue>) ?? new Dictionary<TKey, TValue>();
            if (jToken.Type == JTokenType.Array)
            {
                foreach (JToken item in jToken)
                {
                    using JsonReader reader2 = item.CreateReader();
                    serializer.Populate(reader2, dictionary);
                }
            }
            else if (jToken.Type == JTokenType.Object)
            {
                using JsonReader reader3 = jToken.CreateReader();
                serializer.Populate(reader3, dictionary);
            }

            return new List<TValue>(dictionary.Values);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => serializer.Serialize(writer, value);
    }
}
