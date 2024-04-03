using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace LoanWorkflow.Services.DTO.Acra
{
    [XmlRoot(ElementName = "Guarantee")]
    public record GuaranteeDTO
    {
        [XmlElement(ElementName = "CreditID")]
        public string CreditID { get; set; }

        [XmlElement(ElementName = "SourceName")]
        public string SourceName { get; set; }

        [XmlElement(ElementName = "ContractAmount")]
        public string ContractAmount { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }

        [XmlIgnore]
        public DateTime? ActualCreditStart { get; set; }

        [XmlElement("ActualCreditStart")]
        public string ActualCreditStartString
        {
            get
            {
                DateTime? actualCreditStart = this.ActualCreditStart;
                ref DateTime? local = ref actualCreditStart;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.ActualCreditStart = new DateTime?(result);
            }
        }

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
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.CreditStart = new DateTime?(result);
            }
        }

        [XmlIgnore]
        public DateTime? GuaranteeCancellationDate { get; set; }

        [XmlElement("GuaranteeCancellationDate")]
        public string GuaranteeCancellationDateString
        {
            get
            {
                DateTime? cancellationDate = this.GuaranteeCancellationDate;
                ref DateTime? local = ref cancellationDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.GuaranteeCancellationDate = new DateTime?(result);
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
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.LastInstallment = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "AnnualRate")]
        public string AnnualRate { get; set; }

        [XmlElement(ElementName = "AmountDue")]
        public string AmountDue { get; set; }

        [XmlIgnore]
        public DateTime? GuaranteeLastPaymentDate { get; set; }

        [XmlElement("GuaranteeLastPaymentDate")]
        public string GuaranteeLastPaymentDateString
        {
            get
            {
                DateTime? guaranteeLastPaymentDate = this.GuaranteeLastPaymentDate;
                ref DateTime? local = ref guaranteeLastPaymentDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.GuaranteeLastPaymentDate = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "TheGuaranteeClass")]
        public string TheGuaranteeClass { get; set; }

        [XmlElement(ElementName = "CreditStatus")]
        public string CreditStatus { get; set; }

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

        [XmlElement(ElementName = "CreditAmount")]
        public string CreditAmount { get; set; }

        [XmlElement(ElementName = "CreditScope")]
        public string CreditScope { get; set; }

        [XmlElement(ElementName = "CreditUsePlace")]
        public string CreditUsePlace { get; set; }

        [XmlIgnore]
        public DateTime? IncomingDate { get; set; }

        [XmlElement("IncomingDate")]
        public string IncomingDateString
        {
            get
            {
                DateTime? incomingDate = this.IncomingDate;
                ref DateTime? local = ref incomingDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.IncomingDate = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "CreditType")]
        public string CreditType { get; set; }

        [XmlElement(ElementName = "PaymentAmount")]
        public string PaymentAmount { get; set; }

        [XmlElement(ElementName = "AmountOverdue")]
        public string AmountOverdue { get; set; }

        [XmlElement(ElementName = "OutstandingPercent")]
        public string OutstandingPercent { get; set; }

        [XmlIgnore]
        public DateTime? ClassificationLastDate { get; set; }

        [XmlElement("ClassificationLastDate")]
        public string ClassificationLastDateString
        {
            get
            {
                DateTime? classificationLastDate = this.ClassificationLastDate;
                ref DateTime? local = ref classificationLastDate;
                return !local.HasValue ? (string)null : local.GetValueOrDefault().ToString();
            }
            set
            {
                DateTime result;
                if (!DateTime.TryParseExact(value, "dd-MM-yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                    return;
                this.ClassificationLastDate = new DateTime?(result);
            }
        }

        [XmlElement(ElementName = "ProlongationsNum")]
        public string ProlongationsNum { get; set; }

        [XmlElement(ElementName = "GuarantorAmount")]
        public string GuarantorAmount { get; set; }

        [XmlElement(ElementName = "CreditNotes")]
        public string CreditNotes { get; set; }

        [XmlElement(ElementName = "OverdueDays")]
        public string OverdueDays { get; set; }

        [XmlElement(ElementName = "GuarantorOverdueDays")]
        public string GuarantorOverdueDays { get; set; }

        [XmlElement(ElementName = "PledgeSubject")]
        public string PledgeSubject { get; set; }

        [XmlElement(ElementName = "CollateralNotes")]
        public string CollateralNotes { get; set; }

        [XmlElement(ElementName = "CollateralAmount")]
        public string CollateralAmount { get; set; }

        [XmlElement(ElementName = "CollateralCurrency")]
        public string CollateralCurrency { get; set; }

        [XmlElement(ElementName = "OutstandingDaysCount")]
        [Column(TypeName = "jsonb")]
        public OutstandingDaysCountDTO OutstandingDaysCount { get; set; }
    }
}