using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.File;
using LoanWorkflow.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.FileManagment
{
    public class DocTypesService(
        IDbSetAccessor<DAL.Entities.File.DocType> dbSetAccessor
        ) : Service<DAL.Entities.File.DocType>(dbSetAccessor), IDocTypeService
    {
        public async Task<List<DocType>> GetDocTypes()
        {
            return await Repository.ToListAsync();
        }
    }
}
