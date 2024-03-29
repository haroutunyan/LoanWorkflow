using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Loan
{
    public class LoanProductSettingService(IDbSetAccessor<LoanProductSetting> dbSetAccessor)
        : Service<LoanProductSetting>(dbSetAccessor), ILoanProductSettingService
    {
        public async Task<List<LoanProductSetting>> GetCurrenciesByRepaymentTypes(short repaymentTypeId, short productTypeId)
        {
            return await Repository
                          .Where(x => (short)x.RepaymentType == repaymentTypeId
                                   && x.ProductTypeId == productTypeId)
                          .Include(x => x.LoanSetting).ToListAsync();
        }

        public async Task<LoanSetting> GetLoanSettingByProductSettingId(int productSettingId)
        {
            var setting = await Repository.Where(x => x.Id == productSettingId)
                .Include(x => x.LoanSetting)
                .FirstOrDefaultAsync() ?? throw new Exception();
            return setting.LoanSetting;
        }
    }
}
