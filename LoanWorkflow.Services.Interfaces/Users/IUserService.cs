using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Users
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByIdAsync(long id);
        Task<User> GetByUserNameAsync(string username);
    }
}