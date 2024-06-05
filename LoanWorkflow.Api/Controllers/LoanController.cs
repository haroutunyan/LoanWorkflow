using Azure.Core;
using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Common;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.DTO.PersonalInfo;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Interfaces.Ekeng;
using LoanWorkflow.Services.Interfaces.Loan;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class LoanController(
        ApiContext apiContext,
        ILoanTypeService loanTypeService,
        ILoanProductTypeService loanProductTypeService,
        ILoanProductSettingService loanProductSettingService,
        IEkengService ekengService,
        IPersonalInfoService personalInfoService,
        IClientService clientService,
        IApplicationService applicationService,
        IDraftApplicationService draftApplicationService,
        IPersonalInfoBaseService personalInfoBaseService)
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanTypesResponse>>> GetAllLoanTypes()
        {
            return new ApiResponse<IEnumerable<LoanTypesResponse>>
                (ApiContext.Mapper.Map<IEnumerable<LoanTypesResponse>>
                (await loanTypeService.GetAllLoanTypes()));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>> GetCurrenciesByProductTypeId(
            short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanCurrenciesByProductTypeIdDTO>>
                (await loanProductTypeService.GetCurrenciesByProductTypeId(productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanRepaymentTypesDTO>>> GetRepaymentTypes(short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanRepaymentTypesDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanRepaymentTypesDTO>>
                (await loanProductTypeService.GetRepaymentTypes(productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>> GetRepaymentTypesByCurrency(
           string currencyCode,
           short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanRepaymentTypesByCurrencyDTO>>
                (await loanProductSettingService.GetRepaymentTypesByCurrency(currencyCode, productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>> GetCurrenciesByRepaymentTypes(
            short repaymentTypeId,
            short productTypeId)
        {
            return new ApiResponse<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>
                (ApiContext.Mapper.Map<IEnumerable<LoanCurrenciesByRepaymentTypeIdDTO>>
                (await loanProductSettingService.GetCurrenciesByRepaymentTypes(repaymentTypeId, productTypeId)));
        }

        [HttpPost]
        public async Task<ApiResponse<LoanSettingDTO>> GetLoanSettingByProductSettingId(int productSettingId)
        {
            return new ApiResponse<LoanSettingDTO>
                (ApiContext.Mapper.Map<LoanSettingDTO>
                (await loanProductSettingService.GetLoanSettingByProductSettingId(productSettingId)));
        }

        [HttpPost]
        public async Task<ApiResponse<LoanTypeInfoResponse>> GetLoanTypeInfoByProductSettingId(int productSettingId)
        {
            var maped = ApiContext.Mapper.Map<LoanTypeInfoResponse>(
                await loanProductSettingService.GetLoanTypeInfoByProductSettingId(productSettingId));
            maped.ProductSettingId = productSettingId;
            return new ApiResponse<LoanTypeInfoResponse>(maped);
        }

        [HttpPost]
        public async Task<ApiResponse<PersonalInfoDTO>> AddApplicant(AddApplicantRequest request)
        {
            var draftApplication = await draftApplicationService.Get(e => e.Id == request.ApplicationId)
                ?? throw new DraftApplicationNotFoundException();

            var application = await applicationService.Get(e => e.Id == request.ApplicationId)
                ?? throw new ApplicationNotFoundException();

            if (application.Applicant is null && request.Type != ClientType.Borrower)
                throw new ApplicationDoesNotHaveBorrowerException();

            var personalInfo = await personalInfoService.GetAllPersonalInfos(request.SSN);
            var avv = ApiContext.Mapper.Map<AvvData>(personalInfo.Avv);
           // var acra = ApiContext.Mapper.Map<AvvData>(personalInfo.Acra);
            var acts = new ECivilData 
            {
                
            };
            var ces = ApiContext.Mapper.Map<IEnumerable<EInquest>>(personalInfo.Ces);
            
            return new ApiResponse<PersonalInfoDTO>(personalInfo);
        }

        [HttpPost]
        public async Task<ApiResponse<Guid>> GetNewApplicationId(IdRequest<long> request)
        {
            if (await loanProductSettingService.GetAsNoTracking(e => e.Id == request.Id) is null)
                throw new LoanProductSettingNotFoundException();

            var id = Guid.Parse(HttpContext.TraceIdentifier);
            await draftApplicationService.Add(new DraftApplication
            {
                Id = id,
                LoanProductSettingId = request.Id
            });

            await SaveChangesAsync(UserContext.UserId);

            return new ApiResponse<Guid>(id);
        }
    }
}
