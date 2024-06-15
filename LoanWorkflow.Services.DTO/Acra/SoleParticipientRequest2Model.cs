using LoanWorkflow.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleParticipientRequest2Model
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("KindBorrower")]
        public KindBorrower KindBorrower { get; set; }

        [XmlElement("Person")]
        public List<SoleRequest2Person> Persons { get; set; }

        [XmlElement("RequestTarget")]
        public RequestTarget RequestTarget { get; set; }

        [XmlElement("UsageRange")]
        public UsageRange UsageRange { get; set; }
    }

    public record SoleRequest2Person
    {
        [XmlElement("Identificator")]
        public string Identificator { get; set; }
    }
}
