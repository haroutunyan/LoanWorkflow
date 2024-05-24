using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;

namespace LoanWorkflow.DAL.Entities.Clients
{
    public class Client : Entity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public required string SSN { get; set; }
        public string Document { get; set; }
        public string DocIssuer { get; set; }
        public DateTime DocIssuedDate { get; set; }
        public DateTime DocValidityDate { get; set; }
        public string Address { get; set; }
        public string? ActualAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public required string Email { get; set; }
        public DateTime? ConsentDate { get; set; }
        public required string Type { get; set; }

        public ICollection<Income> Incomes { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
    }
}
