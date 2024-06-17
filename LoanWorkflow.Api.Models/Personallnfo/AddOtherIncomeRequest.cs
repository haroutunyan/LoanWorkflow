using Microsoft.AspNetCore.Http;

namespace LoanWorkflow.Api.Models.Personallnfo
{
    public class AddOtherIncomeRequest
    {
        public Guid PersonalInfoBaseId { get; set; }
        public string TaxpayerNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int ActivityTypeId { get; set; }
        public int ActivityPositionId { get; set; }
        public double ExperienceInYear { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Salary { get; set; }
        public bool IsPreCorruption { get; set; }

        public IFormFile File { get; set; }
        public short FileDocType { get; set; }

    }
}
