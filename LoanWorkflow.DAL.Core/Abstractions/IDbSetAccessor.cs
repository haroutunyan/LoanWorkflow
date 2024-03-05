using LoanWorkflow.DAL.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Core.Abstractions
{
    public interface IDbSetAccessor<T>
        where T : class, IEntity
    {
        DbSet<T> DbSet { get; }
    }
}
