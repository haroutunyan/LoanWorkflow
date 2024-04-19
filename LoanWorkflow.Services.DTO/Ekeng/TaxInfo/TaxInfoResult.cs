using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.TaxInfo
{
    public record TaxInfoResult
    {
        [JsonProperty("responseStatus")]
        public ResponseStatusDTO ResponseStatus { get; set; }

        [JsonProperty("taxPayersInfo")]
        public TaxPayersInfoDTO TaxPayersInfo { get; set; }
    }
}
