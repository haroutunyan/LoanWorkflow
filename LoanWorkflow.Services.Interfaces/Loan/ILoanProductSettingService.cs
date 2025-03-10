﻿using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Loan
{
    public interface ILoanProductSettingService : IService<LoanProductSetting>
    {
        Task<List<LoanProductSetting>> GetCurrenciesByRepaymentTypes(short repaymentTypeId, short productTypeId);
        Task<List<LoanProductSetting>> GetRepaymentTypesByCurrency(string currencyCode, short productTypeId);
        Task<LoanSetting> GetLoanSettingByProductSettingId(int productSettingId);
        Task<LoanType> GetLoanTypeInfoByProductSettingId(int productSettingId);
    }
}
