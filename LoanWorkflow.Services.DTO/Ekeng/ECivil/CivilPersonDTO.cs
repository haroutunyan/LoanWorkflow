using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record CivilPersonDTO
    {
        [JsonProperty("psn")]
        public string Ssn { get; set; }

        [JsonProperty("id_type")]
        public string DocumentType { get; set; }

        [JsonProperty("id_number")]
        public string DocumentNumber { get; set; }

        [JsonProperty("citizenship")]
        public string Citizenship { get; set; }

        [JsonProperty("id_department")]
        public string DocumentDepartment { get; set; }

        [JsonProperty("id_issue_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? DocumentIssueDate { get; set; }

        [JsonProperty("id_expirey_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? DocumentExpiryDate { get; set; }

        [JsonProperty("new_last_name")]
        public string NewLastName { get; set; }

        [JsonProperty("last_name_after_marriage")]
        public string LastNameBeforeMarriage { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("education_level")]
        public string EducationLevel { get; set; }

        [JsonProperty("employment_status")]
        public string EmploymentStatus { get; set; }

        [JsonProperty("marital_status")]
        public string MaritalStatus { get; set; }

        [JsonProperty("marriage_number")]
        public int MarriageNumber { get; set; }

        [JsonProperty("Birth")]
        public CivilPersonBirthDTO Birth { get; set; }

        [JsonProperty("resident")]
        public CivilPersonResidentDTO Resident { get; set; }

        [JsonProperty("base_info")]
        public CivilPersonBaseInfoDTO BaseInfo { get; set; }
    }
}
