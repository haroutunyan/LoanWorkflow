using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Abstractions;
using LoanWorkflow.Services.Interfaces.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanWorkflow.Services.Abstractions
{
    public abstract class Service<TEntity>(
        IDbSetAccessor<TEntity> dbSetAccessor)
        : IService<TEntity>
            where TEntity : class, IEntity
    {
        protected DbSet<TEntity> Repository { get; } = dbSetAccessor.DbSet;

        public virtual async Task<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate)
            => await dbSetAccessor.DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
            => await dbSetAccessor.DbSet
            .FirstOrDefaultAsync(predicate);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate)
            => await dbSetAccessor.DbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
            => await dbSetAccessor.DbSet
            .Where(predicate)
            .ToListAsync();

        public virtual async Task Add(TEntity entity)
            => await dbSetAccessor.DbSet.AddAsync(entity);

        public void Update(TEntity entity)
            => dbSetAccessor.DbSet.Update(entity);

        public async Task AddRange(ICollection<TEntity> entities)
            => await dbSetAccessor.DbSet.AddRangeAsync(entities);
    }

    public abstract class Service
    {
    }
}
