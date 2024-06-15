using LoanWorkflow.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Ekeng
{
    public record RequestPsn
    {
        [FormUrlName("psn")]
        public required string SSN { get; set; }
    }

    public record RequestSsn
    {
        [FormUrlName("ssn")]
        [JsonProperty("ssn")]
        [XmlElement("ssn")]
        public required string SSN { get; set; }
    }
}
