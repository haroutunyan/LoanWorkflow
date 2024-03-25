using LoanWorkflow.Core.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record InsuranceInfoDTO
    {
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? StartDate { get; set; }

        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateFormatConverter), ["yyyy-MM-dd"])]
        public DateTime? EndDate { get; set; }

        [JsonProperty("insurance_name")]
        public string InsuranceName { get; set; }
    }
}
