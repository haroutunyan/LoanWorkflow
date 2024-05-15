using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Loan
{
    public class LoanProductTypeService(IDbSetAccessor<LoanProductType> dbSetAccessor)
        : Service<LoanProductType>(dbSetAccessor), ILoanProductTypeService
    {
        public async Task<List<LoanProductSetting>> GetRepaymentTypes(short productTypeId)
        {
            var productType = (await Repository
                         .Where(x=>x.Id == productTypeId)
                         .Include(x=>x.LoanProductSettings)
                         .FirstOrDefaultAsync()) ?? throw new Exception();

            return productType.LoanProductSettings.DistinctBy(x=>x.RepaymentType).ToList();
        }
        public async Task<List<LoanProductSetting>> GetCurrenciesByProductTypeId(short productTypeId)
        {
            var productType = (await Repository
                         .Where(x=>x.Id == productTypeId)
                         .Include(x=>x.LoanProductSettings)
                         .ThenInclude(x=>x.LoanSetting)
                         .FirstOrDefaultAsync()) ?? throw new Exception();

            return productType.LoanProductSettings.DistinctBy(x=>x.LoanSetting.Currency).ToList();
        }

    }
}
