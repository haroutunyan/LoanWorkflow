using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoanWorkflow.Api.Security
{
    internal sealed class ApiAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                try
                {
                    if (filterContext.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                    {
                        var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowNotValidAttribute), true);
                        if (actionAttributes.Length != 0)
                            return;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}