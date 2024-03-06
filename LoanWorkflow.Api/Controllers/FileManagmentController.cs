using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.File;
using LoanWorkflow.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class FileManagmentController(
        ApiContext apiContext,
        IFileManagmentService service)
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<bool> FileUpload([FromForm] SaveFileRequest request)
        {
            var res = await service.SaveFileAsync(request.File);
            await SaveChangesAsync(0);//UserContext.UserId);
            return res;
        }

        [HttpPost]
        public async Task<byte[]> GetFile(Guid Id)
        {
            return await service.GetFileDataAsync(Id);
        }

        [HttpPost]
        public async Task<List<byte[]>> GetAllFiles(List<Guid> Ids)
        {
            return await service.GetFileDataAsync(Ids);
        }

    }
}
