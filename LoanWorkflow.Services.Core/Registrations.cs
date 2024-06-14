using LoanWorkflow.Services.FileManagment;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using LoanWorkflow.Services.Users;
using LoanWorkflow.Services.Interfaces.Loan;
using LoanWorkflow.Services.Loan;
using LoanWorkflow.Services.Interfaces.FileManagment;
using LoanWorkflow.Services.Acra;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Clients;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using LoanWorkflow.Services.PersonalInfo;
using Microsoft.Extensions.DependencyInjection;

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
                new(typeof(IDocTypeService), typeof(DocTypesService)),
                new(typeof(IClientService), typeof(ClientService)),
                new(typeof(IDraftApplicationService), typeof(DraftApplicationService)),
                new(typeof(IPersonalInfoService), typeof(PersonalInfoService)),
                new(typeof(IPersonalInfoBaseService), typeof(PersonalInfoBaseService)),
                new(typeof(IApplicantPersonalInfoService), typeof(ApplicantPersonalInfoService)),
                new(typeof(IApplicantService), typeof(ApplicantService)),
            ];
    }
}
