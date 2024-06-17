using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.Interfaces.Abstractions;


namespace LoanWorkflow.Services.Interfaces.PersonalInfo
{
    public interface IOtherIncomeService : IService<OtherIncome>
    { 
        Task<AddOtherIncomeResponse> AddOtherIncomeAsync(AddOtherIncomeRequest request);
        Task<OtherIncome> GetOtherIncomeAsync(Guid id);
    }
}
