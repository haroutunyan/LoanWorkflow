using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record EVehicleDTO
    {
        [JsonProperty("vin")]
        public string VinCode { get; set; }

        [JsonProperty("reg_num")]
        public string RegNum { get; set; }

        [JsonProperty("cert_num")]
        public string CertNum { get; set; }

        [JsonProperty("owner_cert_id")]
        public string OwnerCertId { get; set; }

        [JsonProperty("engine_power")]
        public string EnginePower { get; set; }

        [JsonProperty("engine_hp")]
        public string EngineHp { get; set; }

        [JsonProperty("engine_num")]
        public string EngineNum { get; set; }

        [JsonProperty("chassis_num")]
        public string ChassisNum { get; set; }

        [JsonProperty("fuel_type")]
        public string FuelType { get; set; }

        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("max_weight")]
        public decimal MaxWeight { get; set; }

        [JsonProperty("body_num")]
        public string BodyNum { get; set; }

        [JsonProperty("temporary_number")]
        public string TemporaryNumber { get; set; }

        [JsonProperty("transit_number")]
        public string TransitNumber { get; set; }

        [JsonProperty("special_notes")]
        public string SpecialNotes { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("recording_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? RecordingDate { get; set; }

        [JsonProperty("inactive")]
        public int Inactive { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("model_code")]
        public string ModelCode { get; set; }

        [JsonProperty("model_name")]
        public string ModelName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("vehicle_type")]
        public string VehicleType { get; set; }

        [JsonProperty("vehicle_type_id")]
        public string VehicleTypeId { get; set; }

        [JsonProperty("vehicle_group")]
        public string VehicleGroup { get; set; }

        [JsonProperty("body_type")]
        public string BodyType { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("number_plate_type")]
        public string NumberPlateType { get; set; }

        [JsonProperty("is_blocked")]
        public int IsBlocked { get; set; }

        [JsonProperty("registration_status")]
        public string RegistrationStatus { get; set; }

        [JsonProperty("lenders")]
        public IEnumerable<LenderDTO> Lenders { get; set; }

        [JsonProperty("insurance_info")]
        public InsuranceInfoDTO InsuranceInfo { get; set; }

        [JsonProperty("owners")]
        public IEnumerable<EPoliceOwnerPersonDTO> Owners { get; set; }

        [JsonProperty("holder")]
        public EPolicePersonDTO Holder { get; set; }
    }
}
