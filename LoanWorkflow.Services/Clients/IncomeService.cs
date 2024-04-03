using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;

namespace LoanWorkflow.Services.Clients
{
    public class IncomeService(IDbSetAccessor<Income> dbSetAccessor)
        : Service<Income>(dbSetAccessor), IIncomeService
    {
    }
}
