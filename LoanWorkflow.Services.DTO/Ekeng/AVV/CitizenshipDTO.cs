using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record CitizenshipDTO
    {
        public string CountryName { get; init; }

        [JsonProperty("Citizenship_StoppedDate")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? CitizenshipStoppedDate { get; init; }

        public string CountryCode { get; init; }

        public string CountryShortName { get; init; }
    }
}
