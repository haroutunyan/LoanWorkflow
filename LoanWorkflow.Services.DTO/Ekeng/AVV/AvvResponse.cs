using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public class AvvResponse
    {
        [JsonProperty("result")]
        public List<AvvResult> Result { get; set; }
    }
}
