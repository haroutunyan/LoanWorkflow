using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "ROWDATA")]
    [XmlType("ROWDATA")]
    public class AcraResult
    {
        public Guid? ParticipientId { get; set; }

        [XmlElement(ElementName = "ReqID")]
        public string ReqID { get; set; }

        [XmlElement(ElementName = "SID")]
        public string SID { get; set; }

        [XmlElement(ElementName = "Error")]
        public string Error { get; set; }

        [XmlElement(ElementName = "AppNumber")]
        public string AppNumber { get; set; }

        [XmlIgnore]
        public DateTime? DateTime { get; set; }

        [XmlElement("DateTime")]
        [Column("DateTimeString")]
        public string DateTimeString
        {
            get
            {
                DateTime? dateTime = this.DateTime;
                ref DateTime? local = ref dateTime;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                if (!System.DateTime.TryParseExact(value, "dd/MM/yyyy HH:mm:ss", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime result))
                    return;
                this.DateTime = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "ReportType")]
        public string ReportType { get; set; }

        [XmlElement(ElementName = "PARTICIPIENT")]
        public ParticipientDTO Participient { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Response")]
        public string Response { get; set; }

        [XmlElement(ElementName = "ErrorDesc")]
        public string ErrorDesc { get; set; }
    }
}