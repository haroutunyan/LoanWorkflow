using LoanWorkflow.Services.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace LoanWorkflow.Services.Interfaces.FileManagment
{
    public interface IFileManagmentService : IService<DAL.Entities.File.File>
    {
        Task<bool> SaveFileAsync(IFormFile file, short type);
        Task<Guid> SaveFileAsyncAndReturnGuId(IFormFile file, short type);
        Task<DAL.Entities.File.File> GetFileInfoAsync(Guid id);
        Task<List<DAL.Entities.File.File>> GetAllFileInfoAsync();
        Task<string> Download(Guid id);
    }
}
