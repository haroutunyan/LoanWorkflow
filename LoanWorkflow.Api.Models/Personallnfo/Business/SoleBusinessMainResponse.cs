using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Business
{
    public record SoleBusinessMainResponse : MainPageResponse
    {
        public IEnumerable<string> Names { get; set; }
    }
}
