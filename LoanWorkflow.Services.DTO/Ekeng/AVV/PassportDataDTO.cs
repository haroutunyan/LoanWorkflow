using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record PassportDataDTO
    {
        [JsonProperty("Passport_Type")]
        public string Type { get; init; }

        [JsonProperty("Passport_Issuance_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? IssuanceDate { get; init; }

        [JsonProperty("Passport_Validity_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ValidityDate { get; init; }

        [JsonProperty("Passport_Validity_Date_FC")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ForeignValidityDate { get; init; }

        [JsonProperty("Passport_Extension_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ExtensionDate { get; init; }

        [JsonProperty("Passport_Extension_Department")]
        public string ExtensionDepartment { get; init; }

        [JsonProperty("Related_Document_Number")]
        public string RelatedDocumentNumber { get; init; }

        [JsonProperty("Related_Document_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? RelatedDocumentDate { get; init; }

        [JsonProperty("Related_Document_Department")]
        public string RelatedDocumentDepartment { get; init; }
    }
}
