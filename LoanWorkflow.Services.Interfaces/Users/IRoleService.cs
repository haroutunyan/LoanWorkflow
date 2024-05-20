using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Users
{
    public interface IRoleService : IService<Role>
    {
        Task<Role?> GetDefaultRoleAsync();
        Task<Role?> GetByNameAsync(string name);
        Task<Role?> GetByIdAsync(int id);
    }
}
