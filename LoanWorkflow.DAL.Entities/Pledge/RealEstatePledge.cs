using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.DAL.Entities.Pledge
{
    public class RealEstatePledge : PledgeBase
    {
        public RealEstatePledge() => Type = PledgeType.RealEstate;
        public Core.Enums.RealEstateType RealEstateType { get; set; }
        public string Address { get; set; }
        public string Square { get; set; }
        public string OwnershipNumber { get; set; }
        public DateOnly OwnershipIssueDate { get; set; }
        public string AppraisalCompany { get; set; }
        public DateOnly AppraisalDate { get; set; }
        public string AppraisalActNumber { get; set; }
        public string Currency { get; set; }
        public decimal AppraisedValue { get; set; }
        public int Count { get; set; }
        public decimal LiquidValue { get; set; }
        public string PledgeCertificateNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
