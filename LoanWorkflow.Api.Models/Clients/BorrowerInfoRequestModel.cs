namespace LoanWorkflow.Api.Models.Clients
{
    public class BorrowerInfoRequestModel
    {
        public required string ClientType { get; set; }
        public DateTime? ConsentDate { get; set; }
        public required string SSN { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
