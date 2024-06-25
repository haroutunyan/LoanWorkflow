using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Tax
{
    public class TaxDetailedResponse
    {
        public string TaxPayerId { get; set; }
        public ICollection<PersonInfoPeriodResponse> PersonInfoPeriods { get; set; }
    }

    public class PersonInfoPeriodResponse
    {
        public DateTime Date { get; set; }
        public PersonInfoResponse PersonInfo { get; set; }
    }

    public class PersonInfoResponse
    {
        public decimal IncomeTax { get; set; }
        public decimal Socialpayments { get; set; }
        public decimal SocialPaymentsPaid { get; set; }
        public int WorkingHours { get; set; }
        public decimal SalaryEquivPayments { get; set; }
        public decimal CivilLowContractPayments { get; set; }
    }
}
