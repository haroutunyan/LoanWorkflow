using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class ApplicantService(IDbSetAccessor<Applicant> dbSetAccessor)
        : Service<Applicant>(dbSetAccessor), IApplicantService
    {
        public override async Task<Applicant> Get(Expression<Func<Applicant, bool>> predicate)
            => await Repository
            .Include(e => e.Client)
            .FirstOrDefaultAsync(predicate);
    }
}
