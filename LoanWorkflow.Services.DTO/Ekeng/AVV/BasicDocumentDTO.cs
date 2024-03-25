using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record BasicDocumentDTO
    {
        [JsonProperty("Basic_Document_Code")]
        public string Code { get; init; }

        [JsonProperty("Basic_Document_Name")]
        public string Name { get; init; }

        [JsonProperty("Basic_Document_Number")]
        public string Number { get; init; }

        [JsonProperty("Basic_Document_Country")]
        public CountryDTO Country { get; init; }
    }
}
