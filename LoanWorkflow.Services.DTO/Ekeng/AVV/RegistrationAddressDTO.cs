using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record RegistrationAddressDTO
    {
        public string LocationCode { get; init; }

        [JsonProperty("Postal_Index")]
        public string PostalIndex { get; init; }

        public string Region { get; init; }

        public string Community { get; init; }

        public string Residence { get; init; }

        public string Street { get; init; }

        public string Building { get; init; }

        [JsonProperty("Building_Type")]
        public string BuildingType { get; init; }

        public string Apartment { get; init; }
    }
}
