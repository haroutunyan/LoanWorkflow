using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class ApplicantPersonalInfoService(IDbSetAccessor<ApplicantPersonalInfo> dbSetAccessor)
        : Service<ApplicantPersonalInfo>(dbSetAccessor), IApplicantPersonalInfoService
    {
        public override async Task<ApplicantPersonalInfo> GetAsNoTracking(Expression<Func<ApplicantPersonalInfo, bool>> predicate) 
            => await Repository
                .Include(e => e.PersonalInfo)
                .FirstOrDefaultAsync(predicate);

    }
}
