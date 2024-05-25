namespace LoanWorkflow.Api.Models.Clients
{
    public class ConnectedClientInfoRequestModel : BorrowerInfoRequestModel
    {
        public required string ConnectionType { get; set; }
        public required string BorrowerSSN { get; set; }
    }
}
