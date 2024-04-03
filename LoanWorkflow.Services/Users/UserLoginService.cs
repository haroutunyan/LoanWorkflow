using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Users
{
    public class UserLoginService(
        IDbSetAccessor<UserLogin> dbSetAccessor) 
        : Service<UserLogin>(dbSetAccessor), IUserLoginService
    {
        public async Task<UserLogin> GetByProvideerAndKeyAsync(long userId, string loginProvider, string providerKey)
            => await Repository
                .FirstOrDefaultAsync(ul => ul.UserId == userId
                && ul.LoginProvider == loginProvider 
                && ul.ProviderKey == providerKey);        

        public void Update(UserLogin userLogin) => Repository.Update(userLogin);
    }
}
