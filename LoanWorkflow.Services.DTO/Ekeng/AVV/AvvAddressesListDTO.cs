using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvAddressesListDTO
    {
        [JsonProperty("AVVAddress")]
        public IEnumerable<AvvAddressDTO> Address { get; init; }
    }
}
