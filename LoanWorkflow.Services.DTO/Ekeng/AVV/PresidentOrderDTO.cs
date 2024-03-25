using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record PresidentOrderDTO
    {
        [JsonProperty("President_Order")]
        public string Order { get; init; }

        [JsonProperty("President_Order_Date")]
        public string PresidentOrderDate { get; init; }
    }
}
