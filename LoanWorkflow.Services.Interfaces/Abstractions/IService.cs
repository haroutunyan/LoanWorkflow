using LoanWorkflow.DAL.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Interfaces.Abstractions
{
    public interface IService<TEntity> where TEntity : class, IEntity
    {
    }

    public interface IService
    { }
}
