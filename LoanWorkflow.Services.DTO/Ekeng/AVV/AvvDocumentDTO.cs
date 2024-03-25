using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvDocumentDTO
    {
        [JsonProperty("Photo_ID")]
        public byte[] Photo { get; init; }

        [JsonProperty("Document_Status")]
        public string DocumentStatus { get; init; }

        [JsonProperty("Document_Type")]
        public string DocumentType { get; init; }

        [JsonProperty("Document_Number")]
        public string DocumentNumber { get; init; }

        [JsonProperty("Other_DocumentType")]
        public string OtherDocumentType { get; init; }

        [JsonProperty("Document_Department")]
        public string DocumentDepartment { get; init; }

        public PresidentOrderDTO PresidentOrder { get; init; }
        public BasicDocumentDTO BasicDocument { get; init; }
        public PassportDataDTO PassportData { get; init; }
        public AvvPersonDTO Person { get; init; }
    }
}
