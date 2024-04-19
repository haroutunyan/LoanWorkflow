using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record ResponseStatusDTO
    {
        [JsonProperty("statuscode")]
        public int StatusCode { get; set; }

        [JsonProperty("statustext")] 
        public string StatusText { get; set; }
    }
}
