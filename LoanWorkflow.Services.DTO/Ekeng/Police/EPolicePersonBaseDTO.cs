using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record class EPolicePersonBaseDTO
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("identification_no")]
        public string IdentificationNo { get; set; }

        [JsonProperty("nationality_country_id")]
        public string NationalityCountryId { get; set; }

        [JsonProperty("psn")]
        public string Psn { get; set; }

        [JsonProperty("is_holder")]
        public int IsHolder { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("is_legal_entity")]
        public int IsLegalEntity { get; set; }

        [JsonProperty("joined_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? JoinedDate { get; set; }

        [JsonProperty("shares")]
        public string Shares { get; set; }

        [JsonProperty("address")]
        public EPoliceAddressDTO Address { get; set; }

        [JsonProperty("reg_address")]
        public EPoliceAddressDTO RegAddress { get; set; }
    }
}
