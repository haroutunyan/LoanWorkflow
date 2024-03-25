using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record RegistrationDataDTO
    {
        [JsonProperty("Registration_Department")]
        public string RegistrationDepartment { get; init; }

        [JsonProperty("Registration_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? RegistrationDate { get; init; }

        [JsonProperty("Registration_Type")]
        public string RegistrationType { get; init; }

        [JsonProperty("Registration_Status")]
        public string RegistrationStatus { get; init; }

        [JsonProperty("Temporary_Registration_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? TemporaryRegistrationDate { get; init; }

        [JsonProperty("Registration_Aim")]
        public RegistrationAimDTO RegistrationAim { get; init; }

        [JsonProperty("UnRegistration_Aim")]
        public RegistrationAimDTO UnRegistrationAim { get; init; }

        [JsonProperty("Registered_Date")]
        public DateTime? RegisteredDate { get; init; }

        [JsonProperty("Registered_Department")]
        public string RegisteredDepartment { get; init; }
    }
}
