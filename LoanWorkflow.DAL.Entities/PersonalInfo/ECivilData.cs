using LoanWorkflow.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class ECivilData : PersonalInfoBase
    {
        public ECivilData() => PersonalInfoType = PersonalInfoType.ECivil;

        public string FullRefNumber { get; set; }
        public string Type { get; set; }
        public string RefNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string OfficeName { get; set; }
        public string CertNum { get; set; }
        public DateTime? CertDate { get; set; }
        public string TrackingId { get; set; }
        public Child Child { get; set; }
        public CivilDeath Death { get; set; }

        public long PresenterId { get; set; }
        public CivilPerson Presenter { get; set; }

        public long PersonId { get; set; }
        public CivilPerson Person { get; set; }

        public long Person2Id { get; set; }
        public CivilPerson Person2 { get; set; }
    }

    public class Child
    {
        public string Ssn { get; set; }
        public CivilPersonBaseInfo BaseInfo { get; set; }
        public int? Gender { get; set; }
        public int? BornChildrenCount { get; set; }
        public int? ChildNumber { get; set; }
        public string BirthStatus { get; set; }
        public CivilPersonBirth Birth { get; set; }
    }

    public class CivilDeath
    {
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public string Reason { get; set; }
        public string Age { get; set; }
        public string Unidentified { get; set; }
    }

    public class CivilPersonResident
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Community { get; set; }
        public string Residence { get; set; }
        public string Street { get; set; }
        public string HouseType { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string Department { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class CivilPersonBirth
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Community { get; set; }
    }

    public class CivilPersonBaseInfo
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
    }
}
