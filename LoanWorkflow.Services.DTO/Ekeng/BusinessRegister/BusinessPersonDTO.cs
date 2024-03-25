using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record BusinessPersonDTO
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("shares")]
        public string Shares { get; set; }

        [JsonProperty("nationality_country_id")]
        public string NationalityCountryId { get; set; }

        [JsonProperty("identification_no")]
        public string IdentificationNo { get; set; }

        [JsonProperty("exec_position")]
        public string Position { get; set; }

        [JsonProperty("left_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTimeOffset? LeftDate { get; set; }

        [JsonProperty("is_founder")]
        public string IsFounder { get; set; }

        [JsonProperty("id_info")]
        public IdInfoDTO IdInfo { get; set; }

        [JsonProperty("share_info")]
        public ShareInfoDTO ShareInfo { get; set; }

        [JsonProperty("address")]
        public EAddressDTO Address { get; set; }
    }
}
