using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record BusinessResultDTO
    {
        [JsonProperty("company")]
        public ECompanyDTO Company { get; set; }
    }
}
