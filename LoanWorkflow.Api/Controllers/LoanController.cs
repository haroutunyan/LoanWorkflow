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
        ILoanProductTypeService _loanProductTypeService,
        ILoanProductSettingService _loanProductSettingService,
        IAcraService acraService
        //ILoanSettingService _loanSettingService
        ) : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<List<LoanTypesResponse>>> GetAllLoanTypes()
        {
            return new ApiResponse<List<LoanTypesResponse>>
                (ApiContext.Mapper.Map<List<LoanTypesResponse>>
                (await _loanTypeservice.GetAllLoanTypes()));
        }
        [HttpPost]
        public async Task<ApiResponse<List<LoanRepaymentTypesDTO>>> GetRepaymentTypes(short productTypeId)
        {
            return new ApiResponse<List<LoanRepaymentTypesDTO>>
                (ApiContext.Mapper.Map<List<LoanRepaymentTypesDTO>>
                (await _loanProductTypeService.GetRepaymentTypes(productTypeId)));
        }
        [HttpPost]
        public async Task<ApiResponse<List<LoanCurrenciesByRepaymentTypeIdDTO>>> GetCurrenciesByRepaymentTypes(short repaymentTypeId, short productTypeId)
        {
            return new ApiResponse<List<LoanCurrenciesByRepaymentTypeIdDTO>>
                (ApiContext.Mapper.Map<List<LoanCurrenciesByRepaymentTypeIdDTO>>
                (await _loanProductSettingService.GetCurrenciesByRepaymentTypes(repaymentTypeId, productTypeId)));
        }
        [HttpPost]
        public async Task<ApiResponse<LoanSettingDTO>> GetLoanSettingByProductSettingId(int productSettingId)
        {
            return new ApiResponse<LoanSettingDTO>
                (ApiContext.Mapper.Map<LoanSettingDTO>
                (await _loanProductSettingService.GetLoanSettingByProductSettingId(productSettingId)));
        }

        [HttpPost]
        public async Task<ApiResponse<LoanTypeInfoResponse>> GetLoanTypeInfoByProductSettingId(int productSettingId)
        {
            var maped = ApiContext.Mapper.Map<LoanTypeInfoResponse>(await _loanProductSettingService.GetLoanTypeInfoByProductSettingId(productSettingId));
            maped.ProductSettingId = productSettingId;
            return new ApiResponse<LoanTypeInfoResponse>(maped);
        }

        [HttpGet]
        [AllowAnonymous]
        public Task GetAcraData() 
            => Task.Run(() => acraService.GetAcraData());
    }
}
