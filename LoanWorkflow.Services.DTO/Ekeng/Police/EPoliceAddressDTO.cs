using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record EPoliceAddressDTO
    {
        [JsonProperty("street1")]
        public string Street1 { get; set; }

        [JsonProperty("street2")]
        public string Street2 { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("house_type")]
        public string HouseType { get; set; }

        [JsonProperty("community")]
        public string Community { get; set; }

        [JsonProperty("city_town")]
        public string CityTown { get; set; }

        [JsonProperty("city_town_code")]
        public string CityTownCode { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("apt")]
        public string Apt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
