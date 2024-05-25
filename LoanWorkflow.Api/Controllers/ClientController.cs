using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Services.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class ClientController(ApiContext apiContext, IClientService _clientService, IClientLoanService _clientLoanService) : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<bool>> BorrowerInfo(BorrowerInfoRequestModel requestModel)
        {
            await _clientService.BorrowerInfo(requestModel);
             await SaveChangesAsync(default);
            return new ApiResponse<bool>(true);
        }

        [HttpPost]
        public async Task<ApiResponse<bool>> ConnectedClientInfo(ConnectedClientInfoRequestModel requestModel)
        {
            await _clientService.ConnectedClientInfo(requestModel);
            await SaveChangesAsync(default);
            return new ApiResponse<bool>(true);
        }

        [HttpPost]
        public async Task<ApiResponse<bool>> ClientLoanApplication(ClientLoanApplicationRequestModel requestModel)
        {
            await _clientLoanService.ClientLoanApplication(requestModel);
            await SaveChangesAsync(default);
            return new ApiResponse<bool>(true);
        }        
        
        [HttpPost]
        public async Task<ApiResponse<GetClientLoanApplicationResponseModel>> GetClientLoanApplication(GetClientLoanApplicationRequestModel requestModel)
        {
            var resp = await _clientLoanService.GetClientLoanApplication(requestModel);
            return new ApiResponse<GetClientLoanApplicationResponseModel>(resp);
        }
    }
}
