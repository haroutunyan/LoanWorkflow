using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;

namespace LoanWorkflow.Services.Clients
{
    internal class ClientService(IDbSetAccessor<Client> dbSetAccessor)
        : Service<Client>(dbSetAccessor), IClientService
    {
    }
}
