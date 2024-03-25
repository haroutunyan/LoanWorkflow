using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record VehiclesResult
    {
        [JsonProperty("result")]
        public virtual List<EVehicleDTO> Result { get; set; }
    }
}
