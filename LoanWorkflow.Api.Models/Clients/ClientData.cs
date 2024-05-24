namespace LoanWorkflow.Api.Models.Clients
{
    public class ClientData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string SSN { get; set; }
        public string Document { get; set; }
        public string DocIssuer { get; set; }
        public DateTime DocIssuedDate { get; set; }
        public DateTime DocValidityDate { get; set; }
        public string Address { get; set; }
    }
}
