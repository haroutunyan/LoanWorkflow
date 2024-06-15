using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record SoleResponse1Person
    {
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

        [XmlElement("Identificator")]
        public string Identificator { get; set; }
    }
}
