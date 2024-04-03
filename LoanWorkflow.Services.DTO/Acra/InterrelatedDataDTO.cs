using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "InterrelatedData")]
    [XmlType("InterrelatedData")]
    public record InterrelatedDataDTO
    {
        [XmlElement(ElementName = "Interrelated")]
        public List<InterrelatedDTO> Interrelated { get; set; }
    }
}