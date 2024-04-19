using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record TaxPayersInfoDTO
    {
        [JsonProperty("taxPayerInfo")]
        public List<TaxPayerInfoDTO> TaxPayerInfo { get; set; }
    }
}
