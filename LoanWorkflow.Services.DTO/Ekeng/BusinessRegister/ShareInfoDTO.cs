using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record ShareInfoDTO
    {
        [JsonProperty("share_value")]
        public string ShareValue { get; set; }

        [JsonProperty("share_count")]
        public string ShareCount { get; set; }

        [JsonProperty("share_percent")]
        public string SharePercent { get; set; }

        [JsonProperty("share_fraction")]
        public string ShareFraction { get; set; }
    }
}
