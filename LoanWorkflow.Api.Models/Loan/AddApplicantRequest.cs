using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Models.Loan
{
    public class AddApplicantRequest : SSNRequest
    {
        public Guid ApplicationId { get; set; }
        public ClientType Type { get; set; }   
    }
}
