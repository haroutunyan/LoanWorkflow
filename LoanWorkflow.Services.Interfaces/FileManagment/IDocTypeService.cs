using LoanWorkflow.DAL.Entities.File;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services
{
    public interface IDocTypeService : IService<DAL.Entities.File.DocType>
    {
        Task<List<DocType>> GetDocTypes();
    }
}
