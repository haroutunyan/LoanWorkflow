using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Tax
{
    public record TaxMainResponse : MainPageResponse
    {
        public IEnumerable<TaxMainDTO> Taxes { get; set; }
    }

    public record TaxMainDTO
    {
        public string TaxPayerId { get; set; }
        public decimal SalaryEquivPayments { get; set; }
        public decimal CivilLowContractPayments { get; set; }
    }
}
