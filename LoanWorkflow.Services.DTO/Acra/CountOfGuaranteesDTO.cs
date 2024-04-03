using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "CountOfGuarantees")]
    [XmlType("CountOfGuarantees")]
    public record CountOfGuaranteesDTO
    {
        [XmlElement(ElementName = "Current")]
        public string Current { get; set; }

        [XmlElement(ElementName = "Closed")]
        public string Closed { get; set; }

        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
    }
}