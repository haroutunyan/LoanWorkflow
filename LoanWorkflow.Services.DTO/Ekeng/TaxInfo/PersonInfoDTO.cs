using Newtonsoft.Json;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record PersonInfoDTO
    {
        [JsonProperty("incomeTax")]
        public decimal IncomeTax { get; set; }

        [JsonProperty("socialpayments")]
        public decimal Socialpayments { get; set; }

        [JsonProperty("socialpaymentspaid")]
        public decimal SocialPaymentsPaid { get; set; }

        [JsonProperty("workinghours")]
        public int WorkingHours { get; set; }

        [JsonProperty("salaryEquivPayments")]
        public decimal SalaryEquivPayments { get; set; }

        [JsonProperty("civilLowContractPayments")]
        public decimal CivilLowContractPayments { get; set; }
    }
}
