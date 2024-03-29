using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class AvvData : PersonalInfoBase
    {
        public AvvData() => PersonalInfoType = PersonalInfoType.Avv;
        public string PublicServiceNumber { get; set; }
        public bool SsnIndicator { get; set; }
        public bool IsDead { get; set; }
        public DateTime? DeathDate { get; set; }
        public IEnumerable<AvvDocument> AvvDocuments { get; set; }
        public IEnumerable<AvvAddress> AvvAddresses { get; set; }
    }

    public class AvvDocument
    {
        public string PhotoPath { get; set; }
        public string DocumentStatus { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string OtherDocumentType { get; set; }
        public string DocumentDepartment { get; set; }
        public BasicDocument BasicDocument { get; set; }
        public PassportData PassportData { get; set; }
        public AvvPerson Person { get; set; }
    }

    public class AvvAddress
    {
        public RegistrationAddress RegistrationAddress { get; set; }
        public ResidenceDocument ResidenceDocument { get; set; }
        public RegistrationData RegistrationData { get; set; }
    }

    public class RegistrationAddress
    {
        public string LocationCode { get; set; }
        public string PostalIndex { get; set; }
        public string Region { get; set; }
        public string Community { get; set; }
        public string Residence { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string BuildingType { get; set; }
        public string Apartment { get; set; }
    }

    public class ResidenceDocument
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentDepartment { get; set; }
        public DateTime? ResidenceDocumentDate { get; set; }
        public string DocumentValidityDate { get; set; }
    }

    public class RegistrationData
    {
        public string RegistrationDepartment { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime? TemporaryRegistrationDate { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public string RegisteredDepartment { get; set; }
    }

    public class BasicDocument
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortName { get; set; }
    }

    public class PassportData
    {
        public string Type { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public DateTime? ForeignValidityDate { get; set; }
        public DateTime? ExtensionDate { get; set; }
        public string ExtensionDepartment { get; set; }
        public string RelatedDocumentNumber { get; set; }
        public DateTime? RelatedDocumentDate { get; set; }
        public string RelatedDocumentDepartment { get; set; }
    }

    public class AvvPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Genus { get; set; }
        public string EnglishLastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishPatronymicName { get; set; }
        public string BirthRegion { get; set; }
        public string BirthCommunity { get; set; }
        public string BirthResidence { get; set; }
        public string BirthAddress { get; set; }
        public string BirthCountryName { get; set; }
        public string BirthCountryCode { get; set; }
        public string BirthCountryShortName { get; set; }
        public ICollection<Citizenship> Citizenships { get; set; }
        public string NationalityName { get; set; }
        public string NationalityCode { get; set; }
    }

    public class Citizenship
    {
        public string CountryName { get; set; }
        public DateTime? CitizenshipStoppedDate { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortName { get; set; }
    }
}
