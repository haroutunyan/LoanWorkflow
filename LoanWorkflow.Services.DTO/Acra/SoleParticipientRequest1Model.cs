using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleParticipientRequest1Model
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("KindBorrower")]
        public KindBorrower KindBorrower { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("DateofBirth")]
        public string DateofBirth { get; set; }

        [XmlElement("PassportNumber")]
        public string PassportNumber { get; set; }

        [XmlElement("SocCardNumber")]
        public string SocCardNumber { get; set; }

        [XmlElement("IdCardNumber")]
        public string IdCardNumber { get; set; }

        [XmlElement("RequestTarget")]
        public RequestTarget RequestTarget { get; set; }

        [XmlElement("UsageRange")]
        public UsageRange UsageRange { get; set; }
    }
}
