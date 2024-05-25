using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Clients
{
    public interface IClientLoanService : IService<ClientLoans>
    {
        Task ClientLoanApplication(ClientLoanApplicationRequestModel requestModel);
        Task<GetClientLoanApplicationResponseModel> GetClientLoanApplication(GetClientLoanApplicationRequestModel requestModel);
    }
}
