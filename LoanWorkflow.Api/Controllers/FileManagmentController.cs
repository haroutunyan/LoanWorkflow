using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.File.Request;
using LoanWorkflow.Api.Models.File.Response;
using LoanWorkflow.Services.Interfaces.FileManagment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class FileManagmentController(
        ApiContext apiContext,
        IFileManagmentService service)
        : ApiControllerBase(apiContext)
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<bool>> FileUpload([FromForm] SaveFileRequest request)
        {
            var res = await service.SaveFileAsync(request.File,request.DocType);
            await SaveChangesAsync(0);
            return new ApiResponse<bool>(res);
        }

        [HttpPost]
        public async Task<ApiResponse<FileInfoResponse>> GetFileInfo(Guid Id)
        {
            return new ApiResponse<FileInfoResponse>(
                ApiContext.Mapper.Map<FileInfoResponse>
                (await service.GetFileInfoAsync(Id)));
        }

        [HttpPost]
        public async Task<ApiResponse<List<FileInfoResponse>>> GetAllFiles()
        {
            return new ApiResponse<List<FileInfoResponse>>(
                ApiContext.Mapper.Map<List<FileInfoResponse>>
                (await service.GetAllFileInfoAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {
            var filePath = await service.Download(id);
            if(!System.IO.File.Exists(filePath))
                 throw new Exception(); // there handle custom exceptions
            return File(System.IO.File.ReadAllBytes(filePath), "application/octet-stream",Path.GetFileName(filePath));
        }

    }
}
