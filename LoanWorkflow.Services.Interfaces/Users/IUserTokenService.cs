using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Users
{
    public interface IUserTokenService : IService<UserToken>
    {
        Task<UserToken> GetByUserIdLoginProviderAndNameAsync(long userId, string loginProvider, string name);
        UserToken GetByByUserId(long userId);
        void Update(UserToken userToken);
        Task<UserToken> GetByUserIdAndTokenAsync(long userId, string refreshToken);
    }
}
