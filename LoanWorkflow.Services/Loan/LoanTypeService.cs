using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Loan
{
    public class LoanTypeService(IDbSetAccessor<LoanType> dbSetAccessor)
        : Service<LoanType>(dbSetAccessor), ILoanTypeService
    {
        public async Task<List<LoanType>> GetAllLoanTypes()
        {
            return await Repository
                    .Include(x=>x.Childs)
                    .ThenInclude(x => x.LoanProductTypes)
                    .ThenInclude(x => x.LoanProductSettings)
                    .ThenInclude(x => x.LoanSetting)
                    .Where(x => x.ParentId == null)
                    .ToListAsync(); 
        }

    }
}
