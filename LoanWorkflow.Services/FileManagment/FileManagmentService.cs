using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.FileManagment
{
    public class FileManagmentService(IDbSetAccessor<DAL.Entities.File.File> dbSetAccessor) 
        : Service<DAL.Entities.File.File>(dbSetAccessor), IFileManagmentService
    {
        public async Task<bool> SaveFileAsync(IFormFile file, short docType)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            string base64String = Convert.ToBase64String(fileBytes);


            await Repository.AddAsync(new DAL.Entities.File.File
            {
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Extension = Path.GetExtension(file.FileName),
                DocTypeId = docType,
                Data = base64String,
            });

            return true;
        }

        public async Task<DAL.Entities.File.File> GetFileInfoAsync(Guid id)
        {
            return await Repository.Include(x=>x.DocType).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception(); // there handle custom exceptions
        }

        public async Task<List<DAL.Entities.File.File>> GetAllFileInfoAsync()
        {
            return await Repository.Include(x => x.DocType).ToListAsync() ?? throw new Exception(); // there handle custom exceptions
        }


        public async Task<(byte[], string)> Download(Guid id)
        {
            var data = await Repository.FirstOrDefaultAsync(f => f.Id == id) ?? throw new Exception(); // there handle custom exceptions
            return (Convert.FromBase64String(data.Data),data.Name+data.Extension);
        }
    }
}
