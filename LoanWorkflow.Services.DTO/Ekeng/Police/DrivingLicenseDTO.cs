using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.Police
{
    public record DrivingLicenseDTO
    {
        [JsonProperty("reg_num")]
        public string RegNum { get; set; }

        [JsonProperty("classes")]
        public string Classes { get; set; }

        [JsonProperty("inactive")]
        public int Inactive { get; set; }

        [JsonProperty("denied")]
        public int Denied { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("person")]
        public EPolicePersonDTO Person { get; set; }
    }
}
