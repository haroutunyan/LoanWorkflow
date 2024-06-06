using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Services.DTO.PersonalInfo;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class ApplicantController(
        ApiContext apiContext,
        IPersonalInfoService personalInfoService)
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<PersonalInfoDTO>> AddApplicant(SSNRequest request)
        {
            var data = await personalInfoService.GetAllPersonalInfos(request.SSN);
            
        }
    }
}
