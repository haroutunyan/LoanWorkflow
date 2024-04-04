using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record ECivilAct
    {
        [JsonProperty("full_ref_num")]
        public string FullRefNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ref_num")]
        public string RefNumber { get; set; }

        [JsonProperty("registered")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? RegistrationDate { get; set; }

        [JsonProperty("office_name")]
        public string OfficeName { get; set; }

        [JsonProperty("cert_num")]
        public string CertNum { get; set; }

        [JsonProperty("cert_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? CertDate { get; set; }

        [JsonProperty("tracking_id")]
        public string TrackingId { get; set; }

        [JsonProperty("presenter")]
        public CivilPersonDTO Presenter { get; set; }

        [JsonProperty("person")]
        public CivilPersonDTO Person { get; set; }

        [JsonProperty("person2")]
        public CivilPersonDTO Person2 { get; set; }

        [JsonProperty("child")]
        public ChildDTO Child { get; set; }

        [JsonProperty("death")]
        public CivilDeathDTO Death { get; set; }
    }
}
