using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.DTO.Ekeng.TaxInfo;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Ekeng;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    [AllowAnonymous]
    public class PersonalInfoController(
        ApiContext apiContext,
        IEkengService ekengService,
        IAcraService acraService) 
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<AvvResponse>> GetAvvData(SSNRequest request)
            => new ApiResponse<AvvResponse>(
                await ekengService.GetAvvData(request.SSN));

        [HttpPost]
        public async Task<ApiResponse<CivilResult>> GetActs(SSNRequest request)
            => new ApiResponse<CivilResult>(
                await ekengService.GetCivilResult(request.SSN));

        [HttpPost]
        public async Task<ApiResponse<CesResult>> GetCesData(SSNRequest request)
            => new ApiResponse<CesResult>(
                await ekengService.GetCesData(request.SSN));

        [HttpPost]
        public async Task<ApiResponse<PhysicalPersonBusinessResult>> GetBusinessRegisterData(SSNRequest request)
            => new ApiResponse<PhysicalPersonBusinessResult>(
                await ekengService.GetBusinessRegisterData(request.SSN));

        [HttpPost]
        public async Task<ApiResponse<VehiclesResult>> GetVehicle(SSNRequest request)
            => new ApiResponse<VehiclesResult>(
                await ekengService.GetVehicleData(request.SSN));

        [HttpPost]
        public async Task<ApiResponse<AcraResult>> GetAcraData(SSNRequest request)
            => new ApiResponse<AcraResult>(
                acraService.GetAcraData());

        [HttpPost]
        public async Task<ApiResponse<TaxInfoResult>> GetTaxData(SSNRequest request)
            => new ApiResponse<TaxInfoResult>(
                await ekengService.GetTaxData(request.SSN));
    }
}
