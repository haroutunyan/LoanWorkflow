using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.Services.Abstractions;
using Microsoft.AspNetCore.Http;

namespace LoanWorkflow.Services
{
    public class FileManagmentService : Service<DAL.Entities.File.File> , IFileManagmentService 
    {
        public FileManagmentService(IDbSetAccessor<DAL.Entities.File.File> dbSetAccessor) : base(dbSetAccessor)
        {
        }

        public async Task<bool> SaveFileAsync(IFormFile file)
        {
            // Convert file to Base64 string

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            string base64String = Convert.ToBase64String(fileBytes);
            

            await Repository.AddAsync(new DAL.Entities.File.File { });
            ////ther write logic for save in DB

            return true;
        }

        public async Task<byte[]> GetFileDataAsync(Guid Id)
        {
            byte[] fileData = null;


            //get file data from DB convert to byte and take back;
            //fileData = Convert.FromBase64String(base64String);

            return fileData;
        }

        public async Task<List<byte[]>> GetFileDataAsync(List<Guid> Ids)
        {
            List<byte[]> files = [];


            //get file data from DB convert to byte and take back;
            //fileData = Convert.FromBase64String(base64String);

            return files;
        }
    }
}
