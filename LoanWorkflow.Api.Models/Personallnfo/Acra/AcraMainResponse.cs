using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Acra
{
    public record AcraMainResponse : MainPageResponse
    {
        public bool IsResident { get; set; }
        public byte ActiveLoanCount { get; set; }
        public byte PaidOffLoanCount { get; set; }
        public byte ActiveGuaranteeCount { get; set; }
        public byte PaidOffGuaranteeCount { get; set; }
        public decimal ActualLoanAmount { get; set; }
        public decimal ActualGuranateeAmount { get; set; }
    }
}
