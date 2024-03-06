using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.File.Request;
using LoanWorkflow.Api.Models.File.Response;
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
            var res = await service.SaveFileAsync(request.File,request.DocType);
            await SaveChangesAsync(0);//UserContext.UserId);
            return res;
        }

        [HttpPost]
        public async Task<FileInfoResponse> GetFileInfo(Guid Id)
        {
            return ApiContext.Mapper.Map<FileInfoResponse>(await service.GetFileInfoAsync(Id));
        }

        [HttpPost]
        public async Task<List<FileInfoResponse>> GetAllFiles()
        {
            return ApiContext.Mapper.Map<List<FileInfoResponse>>(await service.GetAllFileInfoAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {
            (byte[] bytes, string name)  = await service.Download(id);
            return File(bytes, "application/octet-stream",name);
        }

    }
}
