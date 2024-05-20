using LoanWorkflow.DAL.Entities.Abstractions;
using System.Linq.Expressions;

namespace LoanWorkflow.Services.Interfaces.Abstractions
{
    public interface IService<TEntity> where TEntity : class, IEntity
    {
        Task Add(TEntity entity);
        void Update(TEntity entity);        
        Task<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IService
    { }
}
