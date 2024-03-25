using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record CivilPersonBaseInfoDTO
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fathers_name")]
        public string FathersName { get; set; }

        [JsonProperty("birth_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}
