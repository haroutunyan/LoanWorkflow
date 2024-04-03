using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng
{
    public record AvvResult
    {
        [JsonProperty("PNum")]
        public string PublicServiceNumber { get; init; }

        [JsonProperty("SSN_Indicator")]
        public bool SsnIndicator { get; init; }

        [JsonProperty("IsDead")]
        public bool IsDead { get; init; }

        [JsonProperty("DeathDate")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? DeathDate { get; init; }

        [JsonProperty("AVVDocuments")]
        public AvvDocumentsListDTO AvvDocuments { get; init; }

        [JsonProperty("AVVAddresses")]
        public AvvAddressesListDTO AvvAddresses { get; init; }
    }

    public record AvvDocumentsListDTO
    {
        [JsonProperty("Document")]
        public IEnumerable<AvvDocumentDTO> Document { get; init; }
    }

    public record AvvDocumentDTO
    {
        [JsonProperty("Photo_ID")]
        public byte[] Photo { get; init; }

        [JsonProperty("Document_Status")]
        public string DocumentStatus { get; init; }

        [JsonProperty("Document_Type")]
        public string DocumentType { get; init; }

        [JsonProperty("Document_Number")]
        public string DocumentNumber { get; init; }

        [JsonProperty("Other_DocumentType")]
        public string OtherDocumentType { get; init; }

        [JsonProperty("Document_Department")]
        public string DocumentDepartment { get; init; }

        public PresidentOrderDTO PresidentOrder { get; init; }
        public BasicDocumentDTO BasicDocument { get; init; }
        public PassportDataDTO PassportData { get; init; }
        public AvvPersonDTO Person { get; init; }
    }

    public record AvvAddressesListDTO
    {
        [JsonProperty("AVVAddress")]
        public IEnumerable<AvvAddressDTO> Address { get; init; }
    }

    public record AvvAddressDTO
    {
        public RegistrationAddressDTO RegistrationAddress { get; init; }
        public ResidenceDocumentDTO ResidenceDocument { get; init; }
        public RegistrationDataDTO RegistrationData { get; init; }
    }

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

    public record ResidenceDocumentDTO
    {
        [JsonProperty("Residence_Document_Type")]
        public string DocumentType { get; init; }

        [JsonProperty("Residence_Document_Number")]
        public string DocumentNumber { get; init; }

        [JsonProperty("Residence_Document_Department")]
        public string DocumentDepartment { get; init; }

        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        [JsonProperty("Residence_Document_Date")]
        public DateTime? ResidenceDocumentDate { get; init; }

        [JsonProperty("Residence_Document_Validity_Date")]
        public string DocumentValidityDate { get; init; }
    }

    public record RegistrationDataDTO
    {
        [JsonProperty("Registration_Department")]
        public string RegistrationDepartment { get; init; }

        [JsonProperty("Registration_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? RegistrationDate { get; init; }

        [JsonProperty("Registration_Type")]
        public string RegistrationType { get; init; }

        [JsonProperty("Registration_Status")]
        public string RegistrationStatus { get; init; }

        [JsonProperty("Temporary_Registration_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? TemporaryRegistrationDate { get; init; }

        [JsonProperty("Registration_Aim")]
        public RegistrationAimDTO RegistrationAim { get; init; }

        [JsonProperty("UnRegistration_Aim")]
        public RegistrationAimDTO UnRegistrationAim { get; init; }

        [JsonProperty("Registered_Date")]
        public DateTime? RegisteredDate { get; init; }

        [JsonProperty("Registered_Department")]
        public string RegisteredDepartment { get; init; }
    }

    public record RegistrationAimDTO
    {
        [JsonProperty("AimName")]
        public string Name { get; init; }

        [JsonProperty("AimCode")]
        public string Code { get; init; }
    }

    public record PresidentOrderDTO
    {
        [JsonProperty("President_Order")]
        public string Order { get; init; }

        [JsonProperty("President_Order_Date")]
        public string PresidentOrderDate { get; init; }
    }

    public record BasicDocumentDTO
    {
        [JsonProperty("Basic_Document_Code")]
        public string Code { get; init; }

        [JsonProperty("Basic_Document_Name")]
        public string Name { get; init; }

        [JsonProperty("Basic_Document_Number")]
        public string Number { get; init; }

        [JsonProperty("Basic_Document_Country")]
        public CountryDTO Country { get; init; }
    }

    public record CountryDTO
    {
        public string CountryName { get; init; }
        public string CountryCode { get; init; }
        public string CountryShortName { get; init; }
    }

    public record PassportDataDTO
    {
        [JsonProperty("Passport_Type")]
        public string Type { get; init; }

        [JsonProperty("Passport_Issuance_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? IssuanceDate { get; init; }

        [JsonProperty("Passport_Validity_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ValidityDate { get; init; }

        [JsonProperty("Passport_Validity_Date_FC")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ForeignValidityDate { get; init; }

        [JsonProperty("Passport_Extension_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? ExtensionDate { get; init; }

        [JsonProperty("Passport_Extension_Department")]
        public string ExtensionDepartment { get; init; }

        [JsonProperty("Related_Document_Number")]
        public string RelatedDocumentNumber { get; init; }

        [JsonProperty("Related_Document_Date")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? RelatedDocumentDate { get; init; }

        [JsonProperty("Related_Document_Department")]
        public string RelatedDocumentDepartment { get; init; }
    }

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

    public record CitizenshipsListDTO
    {
        [JsonProperty("Citizenship")]
        public IEnumerable<CitizenshipDTO> Citizenships { get; init; }
    }

    public record CitizenshipDTO
    {
        public string CountryName { get; init; }

        [JsonProperty("Citizenship_StoppedDate")]
        [JsonConverter(typeof(DateFormatConverter), ["dd/MM/yyyy"])]
        public DateTime? CitizenshipStoppedDate { get; init; }

        public string CountryCode { get; init; }

        public string CountryShortName { get; init; }
    }

    public record NationalityDTO
    {
        public string NationalityName { get; init; }
        public string NationalityCode { get; init; }
    }
}
