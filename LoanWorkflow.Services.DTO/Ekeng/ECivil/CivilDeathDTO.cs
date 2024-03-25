using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record CivilDeathDTO
    {
        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? Date { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("Unidentified")]
        public string Unidentified { get; set; }

        [JsonProperty("address")]
        public CivilPersonResidentDTO Address { get; set; }
    }
}
