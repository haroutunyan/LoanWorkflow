using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record PersonDTO
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("identification_no")]
        public string IdentificationNo { get; set; }

        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("id_num")]
        public string IdNum { get; set; }

        [JsonProperty("national_country_id")]
        public string NationalityCountryId { get; set; }

        [JsonProperty("address")]
        public EAddressDTO Address { get; set; }

        [JsonProperty("id_info")]
        public IdInfoDTO IdInfo { get; set; }

        [JsonProperty("companies")]
        [JsonConverter(typeof(DictionaryToListConverter<string, ECompanyDTO>))]
        public List<ECompanyDTO> Companies { get; set; }
    }
}
