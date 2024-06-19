using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Users
{
    public class UserService(
        IDbSetAccessor<User> dbSetAccessor) 
        : Service<User>(dbSetAccessor), IUserService
    {
        public async Task<User> GetByIdAsync(long id)
            => await Repository.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByUserNameAsync(string username)
            => await Repository
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.NormalizedUserName == username.ToUpper());
    }
}
