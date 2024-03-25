using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;

namespace LoanWorkflow.Services.Loan
{
    public class LoanProductTypeService(IDbSetAccessor<LoanProductType> dbSetAccessor)
        : Service<LoanProductType>(dbSetAccessor), ILoanProductTypeService
    {
    }
}
