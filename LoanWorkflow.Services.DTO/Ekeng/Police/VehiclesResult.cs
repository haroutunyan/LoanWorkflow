using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record VehiclesResult
    {
        [JsonProperty("result")]
        public virtual List<EVehicleDTO> Result { get; set; }
    }
}
