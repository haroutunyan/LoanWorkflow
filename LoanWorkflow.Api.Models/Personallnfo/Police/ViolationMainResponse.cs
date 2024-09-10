using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Personallnfo.Police
{
    public record ViolationMainResponse : MainPageResponse
    {
        public IEnumerable<ViolationMainDTO> Violations { get; set; }
    }

    public record ViolationMainDTO
    {
        public ViolationStatus Status { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
    }
}
