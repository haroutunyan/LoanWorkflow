using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record CivilPersonBirthDTO
    {
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("community")]
        public string Community { get; set; }
    }
}
