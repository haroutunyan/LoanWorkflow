using LoanWorkflow.Api.Models.Personallnfo.Acra;
using LoanWorkflow.Api.Models.Personallnfo.Acts;
using LoanWorkflow.Api.Models.Personallnfo.Avv;
using LoanWorkflow.Api.Models.Personallnfo.Business;
using LoanWorkflow.Api.Models.Personallnfo.Ces;
using LoanWorkflow.Api.Models.Personallnfo.Police;
using LoanWorkflow.Api.Models.Personallnfo.Tax;

namespace LoanWorkflow.Api.Models.Personallnfo
{
    public record PersonalInfoMainResponse
    {
        public ActMainResponse Act {  get; set; }
        public AvvMainResponse Avv { get; set; }
        public SoleBusinessMainResponse Business { get; set; }
        public DriverLicenseMainResponse DriverLicense { get; set; }
        public VehicleMainResponse Vehicle { get; set; }
        public ViolationMainResponse Violation { get; set; }
        public TaxMainResponse Tax { get; set; }
        public AcraMainResponse Acra { get; set; }
        public CesMainResponse Ces { get; set; }
    }
}
