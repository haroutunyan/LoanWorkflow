using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    public record ParticipientDTO
    {
        [XmlElement(ElementName = "ThePresenceData")]
        public string ThePresenceData { get; set; }

        [XmlElement(ElementName = "KindBorrower")]
        public string KindBorrower { get; set; }

        [XmlIgnore]
        public DateTime? FoundationDate { get; set; }

        [XmlElement("FoundationDate")]
        [Column("FoundationDateString")]
        public string FoundationDateString
        {
            get
            {
                DateTime? foundationDate = this.FoundationDate;
                ref DateTime? local = ref foundationDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime result))
                    return;
                this.FoundationDate = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "Director")]
        public string Director { get; set; }

        [XmlElement(ElementName = "ActivityScope")]
        public string ActivityScope { get; set; }

        [XmlElement(ElementName = "RegistryNumber")]
        public string RegistryNumber { get; set; }

        [XmlElement(ElementName = "RequestTarget")]
        public string RequestTarget { get; set; }

        [XmlElement(ElementName = "UsageRange")]
        public string UsageRange { get; set; }

        [XmlElement(ElementName = "ReportNumber")]
        public string ReportNumber { get; set; }

        [XmlElement(ElementName = "FirmName")]
        public string FirmName { get; set; }

        [XmlElement(ElementName = "TaxID")]
        public string TaxID { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "PassportNumber")]
        public string PassportNumber { get; set; }

        [XmlElement(ElementName = "IdCardNumber")]
        public string IdCardNumber { get; set; }

        [XmlElement("DateofBirth")]
        public string DateofBirth { get; set; }

        [XmlElement(ElementName = "SocCardNumber")]
        public string SocCardNumber { get; set; }

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "Residence")]
        public string Residence { get; set; }

        [XmlElement(ElementName = "PersonBankruptIncome")]
        public string PersonBankruptIncome { get; set; }

        [XmlElement(ElementName = "TotalLiabilitiesLoan")]
        public List<TotalLiabilitiesLoanDTO> TotalLiabilitiesLoan { get; set; }

        [XmlElement(ElementName = "TotalLiabilitiesGuarantee")]
        public List<TotalLiabilitiesGuaranteeDTO> TotalLiabilitiesGuarantee { get; set; }

        [XmlElement(ElementName = "SelfInquiryQuantity30")]
        public string SelfInquiryQuantity30 { get; set; }

        [XmlElement(ElementName = "SelfInquiryQuantity")]
        public string SelfInquiryQuantity { get; set; }

        [XmlElement(ElementName = "Loans")]
        public LoansListDTO Loans { get; set; }

        [XmlElement(ElementName = "Guarantees")]
        public GuaranteesListDTO Guarantees { get; set; }

        [XmlElement(ElementName = "CountOfLoans")]
        public CountOfLoansDTO CountOfLoans { get; set; }

        [XmlElement(ElementName = "CountOfGuarantees")]
        public CountOfGuaranteesDTO CountOfGuarantees { get; set; }

        [XmlElement(ElementName = "RequestQuantity30")]
        public string RequestQuantity30 { get; set; }

        [XmlElement(ElementName = "RequestQuantity")]
        public string RequestQuantity { get; set; }

        [XmlElement(ElementName = "InterrelatedData")]
        public InterrelatedDataDTO InterrelatedData { get; set; }

        [XmlElement(ElementName = "Requests")]
        public RequestsListDTO Requests { get; set; }

        [XmlElement(ElementName = "ErrorDesc")]
        public string ErrorDesc { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string AcraId { get; set; }
    }
}