using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Ces
{
    public record CesResult
    {
        [JsonProperty("result")]
        public virtual List<EInquestDTO> Result { get; set; }
    }
}
