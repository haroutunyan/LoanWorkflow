using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo
{
    public record MainPageResponse
    {
        public bool NotFreshData {  get; set; }
        public DateOnly? LastRequestedDate { get; set; }
    }
}
