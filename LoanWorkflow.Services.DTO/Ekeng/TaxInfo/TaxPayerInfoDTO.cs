using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record TaxPayerInfoDTO
    {
        [JsonProperty("taxpayerid")]
        public string TaxPayerId { get; set; }

        [JsonProperty("personInfoPeriods")]
        public PersonInfoPeriodsDTO PersonInfoPeriods { get; set; }
    }
}
