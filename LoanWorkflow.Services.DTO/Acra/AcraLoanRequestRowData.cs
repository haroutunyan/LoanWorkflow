using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "ROWDATA")]
    [XmlType("ROWDATA")]
    public record AcraLoanRequestRowData<T> : AcraBaseRowData
    {
        [XmlElement(ElementName = "AppNumber")]
        public string AppNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "ReportType")]
        public string ReportType { get; set; }

        [XmlElement(ElementName = "Participient")]
        public T Participient { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "ErrorDesc")]
        public string ErrorDesc { get; set; }
    }
}
