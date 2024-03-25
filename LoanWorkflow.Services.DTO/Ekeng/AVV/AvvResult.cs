using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvResult
    {
        [JsonProperty("PNum")]
        public string PublicServiceNumber { get; init; }

        [JsonProperty("SSN_Indicator")]
        public bool SsnIndicator { get; init; }

        [JsonProperty("IsDead")]
        public bool IsDead { get; init; }

        [JsonProperty("DeathDate")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? DeathDate { get; init; }

        [JsonProperty("AVVDocuments")]
        public AvvDocumentsListDTO AvvDocuments { get; init; }

        [JsonProperty("AVVAddresses")]
        public AvvAddressesListDTO AvvAddresses { get; init; }
    }
}
