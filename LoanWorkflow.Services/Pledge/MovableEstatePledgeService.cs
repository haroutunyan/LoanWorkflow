using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Pledge;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Pledge;

namespace LoanWorkflow.Services.Pledge
{
    public class MovableEstatePledgeService(IDbSetAccessor<MovableEstatePledge> dbSetAccessor)
        : Service<MovableEstatePledge>(dbSetAccessor), IMovableEstatePledgeService
    {
    }
}
