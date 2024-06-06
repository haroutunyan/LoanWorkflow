using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo
{
    public class TaxRequest : SSNRequest
    {
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddYears(-1);
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
    }
}
