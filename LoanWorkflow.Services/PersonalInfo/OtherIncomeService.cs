using Azure;
using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.DAL;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.FileManagment;
using LoanWorkflow.Services.Interfaces.FileManagment;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class OtherIncomeService(IDbSetAccessor<OtherIncome> dbSetAccessor,
        IFileManagmentService _fileManagmentService,
        LoanWorkflowContext _dbContext)
        : Service<OtherIncome>(dbSetAccessor), IOtherIncomeService
    {
        public async Task<AddOtherIncomeResponse> AddOtherIncomeAsync(AddOtherIncomeRequest request)
        {
            var response = new AddOtherIncomeResponse
            {
                Succeed = false,
                Error = string.Empty
            };

            try
            {
                var fileGuid = await _fileManagmentService.SaveFileAsyncAndReturnGuId(
                    request.File,
                    (short)DocumentType.Ayl
                );

                var income = new OtherIncome
                {
                    Id = Guid.NewGuid(),
                    TaxpayerNumber = request.TaxpayerNumber,
                    CompanyName = request.CompanyName,
                    Address = request.Address,
                    Phone = request.Phone,
                    ActivityTypeId = request.ActivityTypeId,
                    ActivityPositionId = request.ActivityPositionId,
                    ExperienceInYear = request.ExperienceInYear,
                    GrossSalary = request.GrossSalary,
                    Salary = request.Salary,
                    IsPreCorruption = request.IsPreCorruption,
                    FileId = fileGuid
                };

                await Repository.AddAsync(income);
                await _dbContext.SaveChangesAsync();

                response.Succeed = true;
                return response;
            }
            catch (Exception e)
            {

                response.Succeed = false;
                response.Error = e.Message;

                throw;
            }

        }
        public async Task<OtherIncome> GetOtherIncomeAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            return await dbSetAccessor.DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
