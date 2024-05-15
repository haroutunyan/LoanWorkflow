using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LoanWorkflow.DAL
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
            this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter),
                    BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, []);
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private static Expression<Func<TEntity, bool>> GetSoftDeleteFilter<TEntity>()
            where TEntity : class, IEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.Deleted == null;
            return filter;
        }
    }

    public partial class LoanWorkflowContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.BaseType == null && typeof(IEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                    var props = entityType.GetProperties().Where(p => p.Name == "Deleted").ToList();
                    var index = entityType.AddIndex(props);
                    index.IsUnique = false;
                    index.SetFilter("[Deleted] IS NULL");
                }
            }

            builder.ApplyConfigurationsFromAssembly(typeof(LoanWorkflowContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }

        private void SetAuditData(long initiator)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity
                        && (e.State == EntityState.Added || e.State == EntityState.Modified));
            DateTime now = DateTime.UtcNow;
            foreach (var entityEntry in entries)
            {
                ((IEntity)entityEntry.Entity).Modified = now;
                ((IEntity)entityEntry.Entity).ModifiedBy = initiator;
                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).Created = now;
                    ((IEntity)entityEntry.Entity).CreatedBy = initiator;
                }
            }
        }
    }

    public class BlankTriggerAddingConvention : IModelFinalizingConvention
    {
        public virtual void ProcessModelFinalizing(
            IConventionModelBuilder modelBuilder,
            IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                var table = StoreObjectIdentifier.Create(entityType, StoreObjectType.Table);
                if (table != null
                    && entityType.GetDeclaredTriggers().All(t => t.GetDatabaseName(table.Value) == null)
                    && (entityType.BaseType == null
                        || entityType.GetMappingStrategy() != RelationalAnnotationNames.TphMappingStrategy))
                {
                    entityType.Builder.HasTrigger(table.Value.Name + "_Trigger");
                }

                foreach (var fragment in entityType.GetMappingFragments(StoreObjectType.Table))
                {
                    if (entityType.GetDeclaredTriggers().All(t => t.GetDatabaseName(fragment.StoreObject) == null))
                    {
                        entityType.Builder.HasTrigger(fragment.StoreObject.Name + "_Trigger");
                    }
                }
            }
        }
    }
}
