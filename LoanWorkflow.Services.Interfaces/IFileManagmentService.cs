using LoanWorkflow.Services.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace LoanWorkflow.Services
{
    public interface IFileManagmentService : IService<DAL.Entities.File.File>
    {
        Task<bool> SaveFileAsync(IFormFile file);
        Task<byte[]> GetFileDataAsync(Guid Id);
        Task<List<byte[]>> GetFileDataAsync(List<Guid> Ids);
    }
}
