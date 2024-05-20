using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Users
{
    public class RoleService(IDbSetAccessor<Role> dbSetAccessor)
        : Service<Role>(dbSetAccessor), IRoleService
    {
        public async Task<Role?> GetByIdAsync(int id)
        {
            return await Repository.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await Repository.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Role?> GetDefaultRoleAsync()
        {
            return await Repository.FirstOrDefaultAsync();
        }
    }
}
