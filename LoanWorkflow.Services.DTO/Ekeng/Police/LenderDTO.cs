using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record LenderDTO
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("nationality_country_id")]
        public string NationalityCountryId { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("identification_no")]
        public string IdentificationNumber { get; set; }

        [JsonProperty("psn")]
        public string Ssn { get; set; }

        [JsonProperty("address")]
        public EAddressDTO Address { get; set; }

        [JsonProperty("shares")]
        public decimal Shares { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("is_legal_entity")]
        public int IsLegalEntity { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("allowed_lending")]
        public string AllowedLending { get; set; }

        [JsonProperty("joined_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? JoinedDate { get; set; }
    }
}
