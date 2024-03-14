using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Entities.Loan
{
    public class Application : Entity
    {
        public Guid Id { get; set; }
        public LoanState State { get; set; }
        public bool IsExpired { get; set; }
        public decimal RequestAmount { get; set; }
        public short RequestDateRange { get; set; }
        public decimal? ActualAmount { get; set; }
        public short? ActualDateRange { get; set; }
        public DateOnly? ContractEndDate { get; set; }
        public decimal AdvancePayment { get; set; }
        public decimal? ApprovedPercent { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public short? ApprovedDateRange { get; set; }
        public DateRangeType DateRangeType { get; set; }
        public string ContractNumber { get; set; }
        public string OTP { get; set; }
        public byte OTPAttemptCount { get; set; }
        public byte PercentConfirmationCount { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public bool IsNotified { get; set; }
        public byte? PreferredDay { get; set; }

        public int LoanProductSettingId { get; set; }
        public LoanProductSetting LoanProductSetting { get; set; }

        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
