namespace LoanWorkflow.DAL.Core.Abstractions
{
    public class DbContextAccessor(
        LoanWorkflowContext dbContext) 
        : IDbContextAccessor
    {
        public int SaveChanges(long initiator, bool acceptAllChangesOnSuccess = true)
            => dbContext.SaveChanges(initiator, acceptAllChangesOnSuccess);

        public Task<int> SaveChangesAsync(
            long initiator,
            bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default) =>
            dbContext.SaveChangesAsync(initiator, acceptAllChangesOnSuccess, cancellationToken);
    }
}
