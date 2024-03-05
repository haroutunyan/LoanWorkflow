using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Core.Abstractions
{
    public interface IDbContextAccessor
    {
        int SaveChanges(long initiator, bool acceptAllChangesOnSuccess = true);
        Task<int> SaveChangesAsync(long initiator, bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default);
    }
}
