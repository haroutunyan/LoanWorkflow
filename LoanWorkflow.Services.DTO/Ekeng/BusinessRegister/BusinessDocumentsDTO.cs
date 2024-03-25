using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public record BusinessDocumentsDTO
    {
        [JsonProperty("statement")]
        public byte[] Statement { get; set; }

        [JsonProperty("charter")]
        public byte[] Charter { get; set; }
    }
}
