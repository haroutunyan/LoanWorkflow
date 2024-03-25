using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public class CivilResult
    {
        [JsonProperty("result")]
        [JsonConverter(typeof(DictionaryToListConverter<string, ECivilAct>))]
        public List<ECivilAct> Result { get; set; }
    }
}
