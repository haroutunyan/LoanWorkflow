using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvResponse : EkengResponseBase
    {
        [JsonProperty("result")]
        public List<AvvResult> Result { get; set; }
    }
}
