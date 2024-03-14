using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Approvers;

namespace LoanWorkflow.Services.Approvers
{
    public class RoleApproverService(IDbSetAccessor<RoleApprover> dbSetAccessor)
        : Service<RoleApprover>(dbSetAccessor), IRoleApproverService
    {
    }
}
