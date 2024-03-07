using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Users
{
    public class UserTokenService(
        IDbSetAccessor<UserToken> dbSetAccessor)
        : Service<UserToken>(dbSetAccessor), IUserTokenService
    {
        public async Task<UserToken> GetByUserIdLoginProviderAndNameAsync(long userId, string loginProvider, string name)
            => await Repository
                .FirstOrDefaultAsync(ut => ut.UserId == userId
                && ut.LoginProvider == loginProvider 
                && ut.Name == name);        

        public UserToken GetByByUserId(long userId)
            => Repository.FirstOrDefault(ut => ut.UserId == userId);

        public void Update(UserToken userToken)
            => Repository.Update(userToken);

        public async Task<UserToken> GetByUserIdAndTokenAsync(long userId, string refreshToken)
            => await Repository.FirstOrDefaultAsync(ut => ut.UserId == userId
            && ut.Value == refreshToken);
    }
}
