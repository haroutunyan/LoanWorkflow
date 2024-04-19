using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Clients
{
    public class ClientService(IDbSetAccessor<Client> dbSetAccessor)
        : Service<Client>(dbSetAccessor), IClientService
    {
        public async Task Add(Client client)
            => await Repository.AddAsync(client);

        public async Task<Client> GetById(long id)
            => await Repository.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Client> GetBySsn(string ssn)
            => await Repository
            .FirstOrDefaultAsync(e => e.SSN == ssn);
    }
}
