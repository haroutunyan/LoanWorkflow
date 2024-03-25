using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.ECivil
{
    public record ChildDTO
    {
        [JsonProperty("psn")]
        public string Ssn { get; set; }

        [JsonProperty("base_info")]
        public CivilPersonBaseInfoDTO BaseInfo { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("count_children")]
        public int BornChildrenCount { get; set; }

        [JsonProperty("child_number")]
        public int ChildNumber { get; set; }

        [JsonProperty("birth_status")]
        public string BirthStatus { get; set; }

        [JsonProperty("birth")]
        public CivilPersonBirthDTO Birth { get; set; }

        [JsonProperty("resident")]
        public CivilPersonResidentDTO Resident { get; set; }
    }
}
