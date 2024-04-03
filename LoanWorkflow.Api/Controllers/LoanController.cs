using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class LoanController(
        ApiContext apiContext,
        ILoanTypeService _loanTypeservice,
        IAcraService acraService
        //ILoanSettingService _loanSettingService,
        //ILoanProductTypeService _loanProductTypeService,
        //ILoanProductSettingService _loanProductSettingService
        ): ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<List<LoanTypesResponse>>> GetAllLoanTypes()
        {
            return new ApiResponse<List<LoanTypesResponse>>
                (ApiContext.Mapper.Map<List<LoanTypesResponse>>
                (await _loanTypeservice.GetAllLoanTypes()));
        }

        [HttpGet]
        [AllowAnonymous]
        public Task GetAcraData() 
            => Task.Run(() => acraService.GetAcraData());
    }
}
