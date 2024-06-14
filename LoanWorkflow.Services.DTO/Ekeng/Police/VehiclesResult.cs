using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record VehiclesResult : EkengResponseBase
    {
        [JsonProperty("result")]
        public List<EVehicleDTO> Result { get; set; }
    }
}
