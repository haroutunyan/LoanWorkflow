using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Security
{
    public sealed class ApiAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
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
