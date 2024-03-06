using LoanWorkflow.Api.Security;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Abstractions
{
    //[ApiAuthorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ApiControllerBase : ControllerBase
    {
        protected ApiContext ApiContext { get; }
        protected UserContext UserContext { get; }
        protected ApiControllerBase(ApiContext apiContext)
        {
            ApiContext = apiContext;
            UserContext = new UserContext(this);
        }

        private int SaveChanges(long initiator)
        {
            return ApiContext.DbContextAccessor.SaveChanges(initiator);
        }

        protected async Task<int> SaveChangesAsync(long initiator)
        {
            return await ApiContext.DbContextAccessor.SaveChangesAsync(initiator, true);
        }
    }
}
