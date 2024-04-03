using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Requests")]
    [XmlType("Requests")]
    public record RequestsListDTO
    {
        [XmlElement(ElementName = "Request")]
        public List<RequestDTO> Request { get; set; }
    }
}