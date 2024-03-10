using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.DAL.Entities.Clients
{
    public class Income : Entity
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Sphere { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public decimal GrossIncome { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
