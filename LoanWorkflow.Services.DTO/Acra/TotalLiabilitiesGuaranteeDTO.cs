using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "TotalLiabilitiesGuarantee")]
    public class TotalLiabilitiesGuaranteeDTO
    {
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; } 
    }
}