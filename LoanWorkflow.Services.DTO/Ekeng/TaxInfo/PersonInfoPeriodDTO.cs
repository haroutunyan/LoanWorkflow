using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record PersonInfoPeriodDTO
    {
        [JsonProperty("date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM"])]
        public DateTime Date { get; set; }

        [JsonProperty("personInfo")]
        public PersonInfoDTO PersonInfo { get; set; }
    }
}
