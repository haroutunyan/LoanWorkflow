using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.DTO.Ekeng.BusinessRegister
{
    public class PhysicalPersonBusinessDTO
    {
        [JsonProperty("person")]
        public PersonDTO Person { get; set; }
    }
}
