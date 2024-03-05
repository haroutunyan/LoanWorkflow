using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.DAL.Core.Abstractions
{
    public static class DbSetExtentions
    {
        public static void SoftDelete<T>(this DbSet<T> dbSet, T entity)
            where T : class, IEntity
        {
            entity.Deleted = DateTime.UtcNow;
            dbSet.Update(entity);
        }
        public static void Undelete<T>(this DbSet<T> dbSet, T entity)
            where T : class, IEntity
        {
            entity.Deleted = null;
            dbSet.Update(entity);
        }
    }
}
