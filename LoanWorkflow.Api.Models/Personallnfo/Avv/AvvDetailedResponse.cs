using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Avv
{
    public record AvvDetailedResponse
    {
        public string PublicServiceNumber { get; set; }
        public bool SsnIndicator { get; set; }
        public bool IsDead { get; set; }
        public DateTime? DeathDate { get; set; }
        public IEnumerable<AvvDocumentResponse> AvvDocuments { get; set; }
        public IEnumerable<AvvAddressResponse> AvvAddresses { get; set; }
    }

    public record AvvDocumentResponse
    {
        public string PhotoPath { get; set; }
        public string DocumentStatus { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string OtherDocumentType { get; set; }
        public string DocumentDepartment { get; set; }
        public BasicDocumentResponse BasicDocument { get; set; }
        public PassportDataResponse PassportData { get; set; }
        public AvvPersonResponse Person { get; set; }
    }

    public record AvvAddressResponse
    {
        public RegistrationAddressResponse RegistrationAddress { get; set; }
        public ResidenceDocumentResponse ResidenceDocument { get; set; }
        public RegistrationDataResponse RegistrationData { get; set; }
    }

    public record RegistrationAddressResponse
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

    public record ResidenceDocumentResponse
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentDepartment { get; set; }
        public DateTime? ResidenceDocumentDate { get; set; }
        public string DocumentValidityDate { get; set; }
    }

    public record RegistrationDataResponse
    {
        public string RegistrationDepartment { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime? TemporaryRegistrationDate { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public string RegisteredDepartment { get; set; }
    }

    public record BasicDocumentResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortName { get; set; }
    }

    public record PassportDataResponse
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

    public record AvvPersonResponse
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
        public ICollection<CitizenshipResponse> Citizenships { get; set; }
        public string NationalityName { get; set; }
        public string NationalityCode { get; set; }
    }

    public record CitizenshipResponse
    {
        public string CountryName { get; set; }
        public DateTime? CitizenshipStoppedDate { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortName { get; set; }
    }
}
