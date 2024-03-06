using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.Services.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Abstractions
{
    public abstract class Service<TEntity>(
        IDbSetAccessor<TEntity> dbSetAccessor) 
        : IService<TEntity>
            where TEntity : class, IEntity
    {
        protected DbSet<TEntity> Repository { get; } = dbSetAccessor.DbSet;
    }

    public abstract class Service
    {
    }
}
