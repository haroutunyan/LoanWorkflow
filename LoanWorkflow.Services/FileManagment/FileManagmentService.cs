using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.FileManagment;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoanWorkflow.Services.FileManagment
{
    public class FileManagmentService(
        IDbSetAccessor<DAL.Entities.File.File> dbSetAccessor,
        IConfiguration configuration)
        : Service<DAL.Entities.File.File>(dbSetAccessor), IFileManagmentService
    {
        public async Task<bool> SaveFileAsync(IFormFile file, short docType)
        {
            var filePath = configuration.GetSection("FilePath").Value ?? string.Empty;

            var newFileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            
            if(!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            await using (var fileStream = new FileStream(Path.Combine(filePath, newFileName + extension), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            await Repository.AddAsync(new DAL.Entities.File.File
            {
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Extension = extension,
                DocTypeId = (DocumentType)docType,
                Path = newFileName + extension,
            });

            return true;
        }
        public async Task<Guid> SaveFileAsyncAndReturnGuId(IFormFile file, short docType)
        {
            var filePath = configuration.GetSection("FilePath").Value ?? string.Empty;

            var newFileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            await using (var fileStream = new FileStream(Path.Combine(filePath, newFileName + extension), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var newFile = new DAL.Entities.File.File
            {
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Extension = extension,
                DocTypeId = (DocumentType)docType,
                Path = newFileName + extension,
            };

            await Repository.AddAsync(newFile);

            return newFile.Id;
        }

        public async Task<DAL.Entities.File.File> GetFileInfoAsync(Guid id)
        {
            return await Repository
                .Include(x => x.DocType)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception(); // there handle custom exceptions
        }

        public async Task<List<DAL.Entities.File.File>> GetAllFileInfoAsync()
        {
            return await Repository
                .Include(x => x.DocType)
                .ToListAsync()
                ?? throw new Exception(); // there handle custom exceptions
        }

        public async Task<string> Download(Guid id)
        {
            var data = await Repository.FirstOrDefaultAsync(f => f.Id == id)
                ?? throw new Exception(); // there handle custom exceptions
            return Path.Combine(configuration.GetSection("FilePath").Value ?? string.Empty , data.Path);
        }
    }
}
