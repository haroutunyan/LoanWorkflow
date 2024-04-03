using System.Globalization;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "InterrelatedLoan")]
    [XmlType("InterrelatedLoan")]
    public record InterrelatedLoanDTO
    {
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }

        [XmlIgnore]
        public DateTime? CreditStart { get; set; }

        [XmlElement("CreditStart")]
        public string CreditStartString
        {
            get
            {
                DateTime? creditStart = this.CreditStart;
                ref DateTime? local = ref creditStart;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.CreditStart = new DateTime?(result);
            }
        }

        [XmlIgnore]
        public DateTime? LastInstallment { get; set; }

        [XmlElement("LastInstallment")]
        public string LastInstallmentString
        {
            get
            {
                DateTime? lastInstallment = this.LastInstallment;
                ref DateTime? local = ref lastInstallment;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime result))
                    return;
                this.LastInstallment = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "ContractAmount")]
        public string ContractAmount { get; set; }

        [XmlElement(ElementName = "AmountDue")]
        public string AmountDue { get; set; }

        [XmlElement(ElementName = "AmountOverdue")]
        public string AmountOverdue { get; set; }

        [XmlElement(ElementName = "OutstandingPercent")]
        public string OutstandingPercent { get; set; }

        [XmlIgnore]
        public DateTime? OutstandingDate { get; set; }

        [XmlElement("OutstandingDate")]
        public string OutstandingDateString
        {
            get
            {
                DateTime? outstandingDate = this.OutstandingDate;
                ref DateTime? local = ref outstandingDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.OutstandingDate = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }

        [XmlElement(ElementName = "CreditClassification")]
        public string CreditClassification { get; set; }

        [XmlElement(ElementName = "InterrelatedSourceName")]
        public string InterrelatedSourceName { get; set; }
    }
}