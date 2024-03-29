using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.PersonalInfo
{
    public class CivilPerson : Entity
    {
        public long Id { get; set; }
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
        public CivilPersonBirth Birth { get; set; }
        public CivilPersonResident Resident { get; set; }
        public CivilPersonBaseInfo BaseInfo { get; set; }
        public ICollection<ECivilData> PresenterECivils { get; set; }
        public ICollection<ECivilData> PersonECivils { get; set; }
        public ICollection<ECivilData> Person2ECivils { get; set; }
    }
}
