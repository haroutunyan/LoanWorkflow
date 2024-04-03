using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Loans")]
    [XmlType("Loans")]
    public class LoansListDTO
    {
        [XmlElement(ElementName = "Loan")]
        public List<LoanDTO> Loan { get; set; }
    }
}