using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "OutstandingDaysCount")]
    [XmlType("OutstandingDaysCount")]
    public class OutstandingDaysCountDTO
    {
        [XmlElement(ElementName = "Year")]
        public List<YearDTO> Year { get; set; }
    }
}