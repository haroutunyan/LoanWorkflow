using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Interrelated")]
    [XmlType("Interrelated")]
    public record InterrelatedDTO
    {
        [XmlElement(ElementName = "DebtorNum")]
        public string DebtorNum { get; set; }

        [XmlElement(ElementName = "InterrelatedLoans")]
        public InterrelatedLoansListDTO InterrelatedLoans { get; set; }
    }
}