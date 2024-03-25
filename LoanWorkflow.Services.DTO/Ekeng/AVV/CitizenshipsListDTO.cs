using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record CitizenshipsListDTO
    {
        [JsonProperty("Citizenship")]
        public IEnumerable<CitizenshipDTO> Citizenships { get; init; }
    }
}
