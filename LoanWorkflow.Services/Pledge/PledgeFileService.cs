using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Pledge;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Pledge;

namespace LoanWorkflow.Services.Pledge
{
    public class PledgeFileService(IDbSetAccessor<PledgeFile> dbSetAccessor)
        : Service<PledgeFile>(dbSetAccessor), IPledgeFileService
    {
    }
}
