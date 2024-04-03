using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "InterrelatedLoans")]
    [XmlType("InterrelatedLoans")]
    public record InterrelatedLoansListDTO
    {
        [XmlElement(ElementName = "InterrelatedLoan")]
        public List<InterrelatedLoanDTO> InterrelatedLoan { get; set; }
    }
}