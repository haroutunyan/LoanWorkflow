using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Guarantees")]
    public record GuaranteesListDTO
    {
        [XmlElement(ElementName = "Guarantee")]
        public List<GuaranteeDTO> Guarantee { get; set; }
    }
}