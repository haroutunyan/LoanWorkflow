using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Year")]
    [XmlType("Year")]
    public class YearDTO
    {
        [XmlElement(ElementName = "Month")]
        public List<MonthDTO> Month { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}