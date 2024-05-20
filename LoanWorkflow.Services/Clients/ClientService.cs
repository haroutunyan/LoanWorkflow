using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanWorkflow.Services.Clients
{
    public class ClientService(
        IDbSetAccessor<Client> dbSetAccessor)
        : Service<Client>(dbSetAccessor), IClientService
    {
    }
}
