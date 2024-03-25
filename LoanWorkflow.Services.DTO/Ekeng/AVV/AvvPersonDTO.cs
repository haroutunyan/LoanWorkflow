using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvPersonDTO
    {
        [JsonProperty("First_Name")]
        public string FirstName { get; init; }

        [JsonProperty("Last_Name")]
        public string LastName { get; init; }

        [JsonProperty("Patronymic_Name")]
        public string PatronymicName { get; init; }

        [JsonProperty("Birth_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? BirthDate { get; init; }

        [JsonProperty("Genus")]
        public string Genus { get; init; }

        [JsonProperty("English_Last_Name")]
        public string EnglishLastName { get; init; }

        [JsonProperty("English_First_Name")]
        public string EnglishFirstName { get; init; }

        [JsonProperty("English_Patronymic_Name")]
        public string EnglishPatronymicName { get; init; }

        [JsonProperty("Birth_Region")]
        public string BirthRegion { get; init; }

        [JsonProperty("Birth_Community")]
        public string BirthCommunity { get; init; }

        [JsonProperty("Birth_Residence")]
        public string BirthResidence { get; init; }

        [JsonProperty("Birth_Address")]
        public string BirthAddress { get; init; }

        [JsonProperty("Birth_Country")]
        public CountryDTO BirthCountry { get; init; }
        public CitizenshipsListDTO Citizenship { get; init; }
        public NationalityDTO Nationality { get; init; }
    }
}
