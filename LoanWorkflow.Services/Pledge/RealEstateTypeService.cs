using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Pledge;

namespace LoanWorkflow.Services.Pledge
{
    public class RealEstateTypeService(IDbSetAccessor<DAL.Entities.Pledge.RealEstateType> dbSetAccessor)
        : Service<DAL.Entities.Pledge.RealEstateType>(dbSetAccessor), IRealEstateTypeService
    {
    }
}
