using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Interfaces.Ekeng;
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
        IAcraService acraService,
        IEkengService ekengService,
        IClientService clientService) 
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanTypesResponse>>> GetAllLoanTypes()
        {
            return new ApiResponse<IEnumerable<LoanTypesResponse>>
                (ApiContext.Mapper.Map<IEnumerable<LoanTypesResponse>>
                (await _loanTypeservice.GetAllLoanTypes()));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>> GetCurrenciesByProductTypeId(
            short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>
                (await _loanProductTypeService.GetCurrenciesByProductTypeId(productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanRepaymentTypesDTO>>> GetRepaymentTypes(short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanRepaymentTypesDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanRepaymentTypesDTO>>
                (await _loanProductTypeService.GetRepaymentTypes(productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>> GetRepaymentTypesByCurrency(
           string currencyCode,
           short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>
                (await _loanProductSettingService.GetRepaymentTypesByCurrency(currencyCode,productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>> GetCurrenciesByRepaymentTypes(
            short repaymentTypeId, 
            short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>
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
            var maped = ApiContext.Mapper.Map<LoanTypeInfoResponse>(
                await _loanProductSettingService.GetLoanTypeInfoByProductSettingId(productSettingId));
            maped.ProductSettingId = productSettingId;
            return new ApiResponse<LoanTypeInfoResponse>(maped);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResponse<Dictionary<int, object>>> AddApplicant(AddApplicantRequest request)
        {
            var result = new Dictionary<int, object>
            {
                { (int)PersonalInfoType.Avv, (await ekengService.GetAvvData(request.SSN)).Result },
                { (int)PersonalInfoType.ECivil, (await ekengService.GetCivilResult(request.SSN)).Result },
                { (int)PersonalInfoType.Acra, acraService.GetAcraData() },
                { (int)PersonalInfoType.BusinessRegister, (await ekengService.GetBusinessRegisterData(request.SSN)).Result },
                { (int)PersonalInfoType.Ces, (await ekengService.GetCesData(request.SSN)).Result },
                { (int)PersonalInfoType.Vehicle, (await ekengService.GetVehicleData(request.SSN)).Result },
                { (int)PersonalInfoType.Tax, (await ekengService.GetTaxData(request.SSN)).TaxPayersInfo }
            };

            return new ApiResponse<Dictionary<int, object>>(result);
        }

    }
}
