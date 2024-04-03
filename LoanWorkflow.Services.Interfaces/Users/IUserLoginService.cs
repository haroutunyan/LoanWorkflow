using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Interfaces.Users
{
    public interface IUserLoginService : IService<UserLogin>
    {
        Task<UserLogin> GetByProvideerAndKeyAsync(long userId, string loginProvider, string providerKey);
        void Update(UserLogin userLogin);
    }
}
