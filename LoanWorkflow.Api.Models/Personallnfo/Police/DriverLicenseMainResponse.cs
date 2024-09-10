using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Personallnfo.Police
{
    public record DriverLicenseMainResponse : MainPageResponse
    {
        public string LicenseClasses { get; set; }
        public DriverLicenseStatus Status { get; set; }
        public bool IsDeprived { get; set; }
        public DateOnly GivenDate { get; set; }
    }
}
