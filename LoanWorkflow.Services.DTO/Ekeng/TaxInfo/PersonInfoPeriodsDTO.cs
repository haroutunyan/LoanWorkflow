using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record PersonInfoPeriodsDTO
    {
        [JsonProperty("personInfoPeriod")]
        public IEnumerable<PersonInfoPeriodDTO> PersonInfoPeriod { get; set; }
    }
}
