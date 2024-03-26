using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Loan
{
    public interface ILoanProductTypeService : IService<LoanProductType>
    {
        Task<List<LoanProductSetting>> GetRepaymentTypes(short productTypeId);
    }
}
