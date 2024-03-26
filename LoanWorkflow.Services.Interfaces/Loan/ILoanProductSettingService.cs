using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Loan
{
    public interface ILoanProductSettingService : IService<LoanProductSetting>
    {
        Task<List<LoanProductSetting>> GetCurrenciesByRepaymentTypes(short repaymentTypeId, short productTypeId);
    }
}
