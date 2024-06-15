using LoanWorkflow.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng
{
    public record CivilRequest : RequestSsn
    {
        [FormUrlName("first_name")]
        public required string FirstName { get; set; }

        [FormUrlName("last_name")]
        public required string LastName { get; set; }
    }
}
