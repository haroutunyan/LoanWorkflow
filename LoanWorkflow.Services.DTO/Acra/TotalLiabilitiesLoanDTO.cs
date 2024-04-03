using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "TotalLiabilitiesLoan")]
    [XmlType("TotalLiabilitiesLoan")]
    public class TotalLiabilitiesLoanDTO
    {
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }
    }
}