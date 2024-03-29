using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record IdInfoDTO
    {
        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("birth_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("passport_no")]
        public string PassportNo { get; set; }

        [JsonProperty("passport_issued_by")]
        public string PassportIssuedBy { get; set; }

        [JsonProperty("passport_issued")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? PassportIssuedDate { get; set; }
    }
}
