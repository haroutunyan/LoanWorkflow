using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public record ECompanyDTO
    {
        [JsonProperty("id")]
        public string EkengId { get; set; }

        [JsonProperty("reg_num")]
        public string RegistratrionNumber { get; set; }

        [JsonProperty("name_am")]
        public string NameAm { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("name_ru")]
        public string NameRu { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("company_type")]
        public string CompanyType { get; set; }

        [JsonProperty("company_type_long")]
        public string CompanyTypeLong { get; set; }

        [JsonProperty("taxid")]
        public string TaxId { get; set; }

        [JsonProperty("company_type_id")]
        public string CompanyTypeId { get; set; }

        [JsonProperty("industry_code")]
        public string IndustryCode { get; set; }

        [JsonProperty("cert_num")]
        public string CertificateNumber { get; set; }

        [JsonProperty("zcode")]
        public string EnterpriseCode { get; set; }

        [JsonProperty("soc_num")]
        public string SocialInsurerCode { get; set; }

        [JsonProperty("inactive")]
        public string Inactive { get; set; }

        [JsonProperty("is_blocked")]
        public int IsBlocked { get; set; }

        [JsonProperty("registered")]
        public DateTimeOffset? RegisteredDate { get; set; }

        [JsonProperty("registration")]
        public string Registration { get; set; }

        [JsonProperty("address")]
        public EAddressDTO Address { get; set; }

        [JsonProperty("docs")]
        public BusinessDocumentsDTO Documents { get; set; }

        [JsonProperty("executive")]
        public BusinessPersonDTO Executive { get; set; }

        [JsonProperty("sole_proprietor")]
        public BusinessPersonDTO SoleProprietor { get; set; }

        [JsonProperty("owners")]
        [JsonConverter(typeof(DictionaryToListConverter<string, BusinessOwnerDTO>))]
        public List<BusinessOwnerDTO> Owners { get; set; }

        public PersonDTO Person { get; set; }
    }
}
