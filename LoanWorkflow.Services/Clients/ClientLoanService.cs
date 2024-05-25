using AutoMapper;
using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Clients
{
    public class ClientLoanService(
        IDbSetAccessor<ClientLoans> dbSetAccessor, IClientService _clientService, 
        ILoanTypeService _loanTypeService, ILoanProductTypeService _loanProductTypeService, IMapper mapper)
        : Service<ClientLoans>(dbSetAccessor), IClientLoanService
    {
        public async Task ClientLoanApplication(ClientLoanApplicationRequestModel requestModel)
        {
            var client = await _clientService.GetBySsnAsync(requestModel.ClientSSN)
                ?? throw new NotFoundException("Client not found");

            var loans = await _loanTypeService.GetLoanTypes();
            var loanProductType = await _loanProductTypeService.GetById(requestModel.LoanProductType)
            ?? throw new WrongInputDataException("Wrong loanProductype");
            var loanType = loans.FirstOrDefault(p => p.Id == requestModel.LoanType)
                ?? throw new WrongInputDataException("Wrong loan type");
            var loanChildType = loanType?.Childs?.FirstOrDefault(p => p.Id == requestModel.LoanId)
                ?? throw new WrongInputDataException("Wrong loan id");

            await Repository.AddAsync(new ClientLoans
            {
                ClientSSN = requestModel.ClientSSN,
                Amount = requestModel.Amount,
                ApplicationId = requestModel.ApplicationId,
                AttachedFile1 = requestModel.FileAttached1,
                AttachedFile2 = requestModel.FileAttached2,
                Currency = requestModel.Currency,
                LoanId = requestModel.LoanId,
                LoanProductTypeId = requestModel.LoanProductType,
                RepaymentType = requestModel.RepaymentType,
                ReceivingMethod = requestModel.ReceivingMethod,
                Duration = requestModel.Duration,
                Percent = requestModel.Percent,
                LoanTypeId = requestModel.LoanType
            });
        }

        public async Task<GetClientLoanApplicationResponseModel> GetClientLoanApplication(GetClientLoanApplicationRequestModel requestModel)
        {
            var clientLoan = await Repository.FirstOrDefaultAsync(p => p.ClientSSN == requestModel.SSN && p.ApplicationId == requestModel.ApplicationId);
            return mapper.Map<GetClientLoanApplicationResponseModel>(clientLoan);
        }
    }
}
