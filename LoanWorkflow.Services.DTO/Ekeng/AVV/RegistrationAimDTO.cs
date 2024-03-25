using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record RegistrationAimDTO
    {
        [JsonProperty("AimName")]
        public string Name { get; init; }

        [JsonProperty("AimCode")]
        public string Code { get; init; }
    }
}
