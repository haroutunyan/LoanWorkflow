using LoanWorkflow.Core.Enums;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleResponse1Participient
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("ThePresenceData")]
        public ACRAThePresenceData ThePresenceData { get; set; }

        [XmlElement("KindBorrower")]
        public KindBorrower KindBorrower { get; set; }

        [XmlElement("RequestTarget")]
        public RequestTarget RequestTarget { get; set; }

        [XmlElement("UsageRange")]
        public UsageRange UsageRange { get; set; }

        [XmlElement("Person")]
        public List<SoleResponse1Person> Person { get; set; }

        [XmlElement("ErrorDesc")]
        public string ErrorDesc { get; set; }
    }
}
