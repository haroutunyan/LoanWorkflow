using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Core.Abstractions
{
    public sealed class DbSetAccessor<T>(
        LoanWorkflowContext dbContext) 
        : IDbSetAccessor<T>
        where T : class, IEntity
    {
        public DbSet<T> DbSet => dbContext.Set<T>();
    }
}
