using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Clients
{
    public interface IClientService : IService<Client>
    {
        Task Add(Client client);
        Task<Client?> GetById(long id);
        Task<Client?> GetBySsn(string ssn);
        Task BorrowerInfo(BorrowerInfoRequestModel requestModel);
    }
}
