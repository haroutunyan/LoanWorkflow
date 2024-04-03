using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Loan
{
    public class LoanTypeInfoResponse
    {
        public int ProductSettingId { get; set; }
        public string Name { get; set; }
        public bool HasPladge { get; set; }
    }
}
