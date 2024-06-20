using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Common;
using LoanWorkflow.Api.Models.Personallnfo.Acts;
using LoanWorkflow.Api.Models.Personallnfo.Avv;
using LoanWorkflow.Api.Models.Personallnfo.Ces;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Ekeng;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace LoanWorkflow.Api.Controllers
{
    public class PersonalInfoController(
        ApiContext apiContext,
        IEkengService ekengService,
        IAcraService acraService,
        IApplicantPersonalInfoService applicantPersonalInfoService,
        IApplicantService applicantService)
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<AvvDetailedResponse>> GetAvvData(IdRequest<long> request)
        {
            var applicant = await applicantService.Get(e => e.Id == request.Id)
                ?? throw new ApplicantNotFoundException();

            var applicantPersonalInfo = await applicantPersonalInfoService
                .GetAsNoTracking(e => e.ApplicantId == request.Id && e.PersonalInfo.PersonalInfoType == PersonalInfoType.Avv)
                ?? throw new AvvNotFoundException();

            return new ApiResponse<AvvDetailedResponse>(
                ApiContext.Mapper.Map<AvvDetailedResponse>(
                    applicantPersonalInfo.PersonalInfo as AvvData));
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<ActDetailedResponse>>> GetActs(IdRequest<long> request)
        {
            var applicant = await applicantService.Get(e => e.Id == request.Id)
                ?? throw new ApplicantNotFoundException();

            var applicantPersonalInfo = await applicantPersonalInfoService
                .GetAllAsNoTracking(e => e.ApplicantId == request.Id && e.PersonalInfo.PersonalInfoType == PersonalInfoType.ECivil);

            if (!applicantPersonalInfo.Any())
            {
                var acts = await ekengService.GetCivilResult(applicant.Client.SSN, applicant.Client.FirstName, applicant.Client.LastName);
                var entities = ApiContext.Mapper.Map<ICollection<ECivilData>>(acts);
                var personalInfos = entities.Select(e => new ApplicantPersonalInfo
                {
                    Applicant = applicant,
                    PersonalInfo = e
                });

                await applicantPersonalInfoService.AddRange(personalInfos.ToList());
                await SaveChangesAsync(UserContext.UserId);

                return new ApiResponse<IEnumerable<ActDetailedResponse>>(ApiContext.Mapper.Map<IEnumerable<ActDetailedResponse>>(entities));
            }

            var response = applicantPersonalInfo.Select(e => ApiContext.Mapper.Map<ActDetailedResponse>(e.PersonalInfo as ECivilData));
            return new ApiResponse<IEnumerable<ActDetailedResponse>>(response);
        }

        [HttpPost]
        public async Task<ApiResponse<IEnumerable<CesDetailedResponse>>> GetCesData(IdRequest<long> request)
        {
            var applicant = await applicantService.Get(e => e.Id == request.Id)
                ?? throw new ApplicantNotFoundException();

            var applicantPersonalInfo = await applicantPersonalInfoService
                .GetAsNoTracking(e => e.ApplicantId == request.Id && e.PersonalInfo.PersonalInfoType == PersonalInfoType.Ces);

            if (applicantPersonalInfo is not null)
            {
                var cesData = applicantPersonalInfo.PersonalInfo as CesData;
                if (cesData.Inquests.Any())
                    return new ApiResponse<IEnumerable<CesDetailedResponse>>(ApiContext.Mapper.Map<IEnumerable<CesDetailedResponse>>(cesData.Inquests));
            }

            var ces = await ekengService.GetCesData(applicant.Client.SSN);
            var entities = ApiContext.Mapper.Map<ICollection<EInquest>>(ces);

            await applicantPersonalInfoService.Add(new ApplicantPersonalInfo
            {
                Applicant = applicant,
                PersonalInfo = new CesData { Inquests = entities }
            });
            await SaveChangesAsync(UserContext.UserId);

            return new ApiResponse<IEnumerable<CesDetailedResponse>>(ApiContext.Mapper.Map<IEnumerable<CesDetailedResponse>>(entities));
        }


        [HttpPost]
        public async Task<ApiResponse<IEnumerable<VehiclesResultResponseModel>>> GetVehicle(IdRequest<long> request)
        {
            var applicant = await applicantService.Get(e => e.Id == request.Id)
              ?? throw new ApplicantNotFoundException();

            var applicantPersonalInfo = await applicantPersonalInfoService
               .GetAsNoTracking(e => e.ApplicantId == request.Id && e.PersonalInfo.PersonalInfoType == PersonalInfoType.Vehicle);

            if (applicantPersonalInfo is not null)
            {
                var vehicleData = applicantPersonalInfo.PersonalInfo as VehicleData;
                if (vehicleData.Vehicles.Any())
                    return new ApiResponse<IEnumerable<VehiclesResultResponseModel>>(ApiContext.Mapper.Map<IEnumerable<VehiclesResultResponseModel>>(vehicleData.Vehicles));
            }

            var vehicles = await ekengService.GetVehicleData(applicant.Client.SSN);
            var entities = ApiContext.Mapper.Map<ICollection<EVehicle>>(vehicles);

            await applicantPersonalInfoService.Add(new ApplicantPersonalInfo
            {
                Applicant = applicant,
                PersonalInfo = new VehicleData { Vehicles = entities }
            });
            await SaveChangesAsync(UserContext.UserId);

            return new ApiResponse<IEnumerable<VehiclesResultResponseModel>>(ApiContext.Mapper.Map<IEnumerable<VehiclesResultResponseModel>>(entities));
        }

    }

    //[HttpPost]
    //public async Task<ApiResponse<PhysicalPersonBusinessResult>> GetBusinessRegisterData(IdRequest<long> request)
    //{
    //    return new ApiResponse<PhysicalPersonBusinessResult>(await ekengService.GetBusinessRegisterData(request.SSN));
    //}

    //[HttpPost]


    //[HttpPost]
    //public async Task<ApiResponse<AcraResult>> GetAcraData(SSNRequest request)
    //    => new ApiResponse<AcraResult>(
    //        acraService.GetAcraData());

    //[HttpPost]
    //public async Task<ApiResponse<TaxInfoResult>> GetTaxData(IdRequest<long> request)
    //{
    //    return new ApiResponse<TaxInfoResult>(await ekengService.GetTaxData(request.SSN, request.StartDate, request.EndDate));
    //}

}
