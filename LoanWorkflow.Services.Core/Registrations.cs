using LoanWorkflow.Services.FileManagment;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using LoanWorkflow.Services.Users;

namespace LoanWorkflow.Services.Core
{
    internal partial class ServicesRegistrator
    {
        private static IEnumerable<InternalServiceDescriptor> servicesDescriptors = 
            [
                new(typeof(IFileManagmentService), typeof(FileManagmentService)),
                new(typeof(IUserService), typeof(UserService)),
                new(typeof(IUserTokenService), typeof(UserTokenService)),
                new(typeof(ISettings), typeof(Settings.Settings)),
                new(typeof(IUserLoginService), typeof(UserLoginService)),
            ];
    }
}
