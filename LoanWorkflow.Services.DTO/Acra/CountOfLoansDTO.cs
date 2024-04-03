using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "CountOfLoans")]
    [XmlType("CountOfLoans")]
    public record CountOfLoansDTO
    {
        [XmlElement(ElementName = "Current")]
        public string Current { get; set; }

        [XmlElement(ElementName = "Closed")]
        public string Closed { get; set; }

        [XmlElement(ElementName = "Total")]
        public string Total { get; set; }
    }
}