using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Approvers;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Approvers;

namespace LoanWorkflow.Services.Approvers
{
    public class ApproverGroupService(IDbSetAccessor<ApproverGroup> dbSetAccessor)
        : Service<ApproverGroup>(dbSetAccessor), IApproverGroupService
    {
    }
}
