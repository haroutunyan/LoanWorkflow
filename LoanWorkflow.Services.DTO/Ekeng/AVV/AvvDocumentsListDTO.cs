using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvDocumentsListDTO
    {
        [JsonProperty("Document")]
        public IEnumerable<AvvDocumentDTO> Document { get; init; }
    }
}
