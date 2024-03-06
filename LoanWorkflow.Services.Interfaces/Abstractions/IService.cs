using LoanWorkflow.DAL.Entities.Abstractions;

namespace LoanWorkflow.Services.Interfaces.Abstractions
{
    public interface IService<TEntity> where TEntity : class, IEntity
    {
    }

    public interface IService
    { }
}
