using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Loan
{
    public interface ILoanTypeService : IService<LoanType>
    {
        Task<List<LoanType>> GetAllLoanTypes();
        Task<IList<GetLoanTypeShortResponseModel>> GetLoanTypes();
    }
}
