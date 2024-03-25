using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record ResidenceDocumentDTO
    {
        [JsonProperty("Residence_Document_Type")]
        public string DocumentType { get; init; }

        [JsonProperty("Residence_Document_Number")]
        public string DocumentNumber { get; init; }

        [JsonProperty("Residence_Document_Department")]
        public string DocumentDepartment { get; init; }

        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        [JsonProperty("Residence_Document_Date")]
        public DateTime? ResidenceDocumentDate { get; init; }

        [JsonProperty("Residence_Document_Validity_Date")]
        public string DocumentValidityDate { get; init; }
    }
}
