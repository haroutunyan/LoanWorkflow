namespace LoanWorkflow.Api.Models.Personallnfo.Acts
{
    public class ActDetailedResponse
    {
        public string FullRefNumber { get; set; }
        public string Type { get; set; }
        public string RefNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string OfficeName { get; set; }
        public string CertNum { get; set; }
        public DateTime? CertDate { get; set; }
        public string TrackingId { get; set; }
        public ChildResponse Child { get; set; }
        //public CivilDeathResponse Death { get; set; }
        //public CivilPersonResponse Presenter { get; set; }
        //public CivilPersonResponse Person { get; set; }
        //public CivilPersonResponse Person2 { get; set; }
    }

    public class ChildResponse
    {
        public string Ssn { get; set; }
        public CivilPersonBaseInfoResponse BaseInfo { get; set; }
        public int? Gender { get; set; }
        public int? BornChildrenCount { get; set; }
        public int? ChildNumber { get; set; }
        public string BirthStatus { get; set; }
        public CivilPersonBirthResponse Birth { get; set; }
    }

    public class CivilDeathResponse
    {
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public string Reason { get; set; }
        public string Age { get; set; }
        public string Unidentified { get; set; }
    }

    public class CivilPersonResidentResponse
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

    public class CivilPersonBirthResponse
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Community { get; set; }
    }

    public class CivilPersonBaseInfoResponse
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
    }

    public class CivilPersonResponse
    {
        public string Ssn { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Citizenship { get; set; }
        public string DocumentDepartment { get; set; }
        public DateTime? DocumentIssueDate { get; set; }
        public DateTime? DocumentExpiryDate { get; set; }
        public string NewLastName { get; set; }
        public string LastNameBeforeMarriage { get; set; }
        public string Gender { get; set; }
        public string EducationLevel { get; set; }
        public string EmploymentStatus { get; set; }
        public string MaritalStatus { get; set; }
        public int? MarriageNumber { get; set; }
        public CivilPersonBirthResponse Birth { get; set; }
        public CivilPersonResidentResponse Resident { get; set; }
        public CivilPersonBaseInfoResponse BaseInfo { get; set; }
    }
}
