using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class PhysicalPersonBusinessData : PersonalInfoBase
    {
        public PhysicalPersonBusinessData() => PersonalInfoType = Core.Enums.PersonalInfoType.BusinessRegister;

        public ICollection<ECompany> Companies { get; set; }
    }

    public class ECompany
    {
        public string RegistratrionNumber { get; set; }
        public string NameAm { get; set; }
        public string NameEn { get; set; }
        public string NameRu { get; set; }
        public string Capital { get; set; }
        public string CompanyType { get; set; }
        public string CompanyTypeLong { get; set; }
        public string TaxId { get; set; }
        public string CompanyTypeId { get; set; }
        public string IndustryCode { get; set; }
        public string CertificateNumber { get; set; }
        public string EnterpriseCode { get; set; }
        public string SocialInsurerCode { get; set; }
        public string Inactive { get; set; }
        public int IsBlocked { get; set; }
        public DateTimeOffset? RegisteredDate { get; set; }
        public string Registration { get; set; }
        public EAddress Address { get; set; }
        public BusinessPerson Executive { get; set; }
        public BusinessPerson SoleProprietor { get; set; }
       // public ICollection<BusinessOwner> Owners { get; set; }
    }

    public class BusinessPerson
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Ssn { get; set; }
        public string Shares { get; set; }
        public string NationalityCountryId { get; set; }
        public string IdentificationNo { get; set; }
        public string Position { get; set; }
        public DateTimeOffset? LeftDate { get; set; }
        public string IsFounder { get; set; }
        //public IdInfo IdInfo { get; set; }
        public EAddress Address { get; set; }
    }

    public class EAddress
    {
        public string House { get; set; }
        public string Community { get; set; }
        public string CityTown { get; set; }
        public string Province { get; set; }
        public string CountryId { get; set; }
        public string Apt { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public string HouseType { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string CityTownCode { get; set; }
        public string Description { get; set; }
        public int DiffFromRes { get; set; }
    }
}
