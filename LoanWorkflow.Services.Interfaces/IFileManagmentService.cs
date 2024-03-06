﻿using LoanWorkflow.Services.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace LoanWorkflow.Services
{
    public interface IFileManagmentService : IService<DAL.Entities.File.File>
    {
        Task<bool> SaveFileAsync(IFormFile file, short type);
        Task<DAL.Entities.File.File> GetFileInfoAsync(Guid id);
        Task<List<DAL.Entities.File.File>> GetAllFileInfoAsync();
        Task<(byte[],string)> Download(Guid id);
    }
}
