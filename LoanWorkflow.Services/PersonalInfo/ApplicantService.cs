using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.PersonalInfo;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class ApplicantService(IDbSetAccessor<Applicant> dbSetAccessor)
        : Service<Applicant>(dbSetAccessor), IApplicantService
    {
    }
}
