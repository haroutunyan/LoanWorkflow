using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Services.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class ClientController(ApiContext apiContext, IClientService _clientService) : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<bool>> BorrowerInfo(BorrowerInfoRequestModel requestModel)
        {
            await _clientService.BorrowerInfo(requestModel);
             await SaveChangesAsync(default);
            return new ApiResponse<bool>(true);
        }
    }
}
