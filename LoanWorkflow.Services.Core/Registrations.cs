using LoanWorkflow.Services.FileManagment;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using LoanWorkflow.Services.Users;
using LoanWorkflow.Services.Interfaces.Loan;
using LoanWorkflow.Services.Loan;

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
                new(typeof(ILoanTypeService), typeof(LoanTypeService)),
                new(typeof(ILoanProductTypeService), typeof(LoanProductTypeService)),
                new(typeof(ILoanProductSettingService), typeof(LoanProductSettingService)),
            ];
    }
}
