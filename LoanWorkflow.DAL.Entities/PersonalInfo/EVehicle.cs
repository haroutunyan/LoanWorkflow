namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class VehicleData : PersonalInfoBase
    {
        public VehicleData() => PersonalInfoType = Core.Enums.PersonalInfoType.Vehicle;
        public ICollection<EVehicle> Vehicles { get; set; }
    }

    public class EVehicle
    {
        public string VinCode { get; set; }
        public string RegNum { get; set; }
        public string CertNum { get; set; }
        public string OwnerCertId { get; set; }
        public string EnginePower { get; set; }
        public string EngineHp { get; set; }
        public string EngineNum { get; set; }
        public string ChassisNum { get; set; }
        public string FuelType { get; set; }
        public decimal? Weight { get; set; }
        public decimal? MaxWeight { get; set; }
        public string BodyNum { get; set; }
        public string TemporaryNumber { get; set; }
        public string TransitNumber { get; set; }
        public string SpecialNotes { get; set; }
        public string Released { get; set; }
        public DateTime? RecordingDate { get; set; }
        public int? Inactive { get; set; }
        public string Model { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public string VehicleType { get; set; }
        public string VehicleTypeId { get; set; }
        public string VehicleGroup { get; set; }
        public string BodyType { get; set; }
        public string Number { get; set; }
        public string NumberPlateType { get; set; }
        public int? IsBlocked { get; set; }
        public string RegistrationStatus { get; set; }
        public ICollection<Lender> Lenders { get; set; }
        public InsuranceInfo InsuranceInfo { get; set; }
        public ICollection<EPolicePersonBase> Owners { get; set; }
    }

    public class Lender
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NationalityCountryId { get; set; }
        public string DocumentType { get; set; }
        public string IdentificationNumber { get; set; }
        public string Ssn { get; set; }
        public decimal? Shares { get; set; }
        public string Currency { get; set; }
        public int? IsLegalEntity { get; set; }
        public string Place { get; set; }
        public string AllowedLending { get; set; }
        public DateTime? JoinedDate { get; set; }
    }

    public class InsuranceInfo
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InsuranceName { get; set; }
    }

    public class EPolicePersonBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DocumentType { get; set; }
        public string IdentificationNo { get; set; }
        public string NationalityCountryId { get; set; }
        public string Psn { get; set; }
        public int IsHolder { get; set; }
        public string Sex { get; set; }
        public int? IsLegalEntity { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string Shares { get; set; }
    }
}
