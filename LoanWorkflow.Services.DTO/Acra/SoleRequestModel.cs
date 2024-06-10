using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleRequestModel
    {
        [XmlElement("ReqID")]
        public required string ReqID { get; set; }

        [XmlAttribute("type")]
        public ACRARequestType Type { get; set; }
    }

    public record SoleLoginRequestModel : SoleRequestModel
    {
        public SoleLoginRequestModel()
            => Type = ACRARequestType.BankLogin;        

        [XmlElement("User")]
        public required string User { get; set; }

        [XmlElement("Password")]
        public required string Password { get; set; }
    }
}
