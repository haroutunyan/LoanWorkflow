using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleResponse
    {
        [XmlElement("ReqID")]
        public string ReqID { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("Response")]
        public string Code { get; set; }

        [XmlElement("SID")]
        public string SessionId { get; set; }

        [XmlElement("Error")]
        public string Error { get; set; }
    }

    [XmlRoot(ElementName = "ROWDATA")]
    public record SoleLoginResponse : SoleResponse { }
}
