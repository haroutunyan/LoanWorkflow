using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Request")]
    [XmlType("Request")]
    public record RequestDTO
    {
        [XmlElement(ElementName = "BankName")]
        public string BankName { get; set; }

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
                if (!System.DateTime.TryParseExact(value, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime result))
                    return;
                this.DateTime = new DateTime?(result.AddHours(-4.0));
            }
        }

        [XmlElement(ElementName = "Reason")]
        public string Reason { get; set; }

        [XmlElement(ElementName = "SubReason")]
        public string SubReason { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
    }
}