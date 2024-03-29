using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Enum;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.DAL.Entities.File;
using LoanWorkflow.Services;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using LoanWorkflow.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class EnumController (ApiContext apiContext,
        IDocTypeService docTypeService,
        ISettings settings) : ApiControllerBase(apiContext)
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<List<DocTypeDTO>>> GetDocTypes()
        { 
            return new ApiResponse<List<DocTypeDTO>>
                (ApiContext.Mapper.Map<List<DocTypeDTO>>
                (await docTypeService.GetDocTypes()));
        }
    }
}
