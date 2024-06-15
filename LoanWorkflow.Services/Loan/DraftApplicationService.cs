using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Loan
{
    public class DraftApplicationService(
        IDbSetAccessor<DraftApplication> dbSetAccessor)
        : Service<DraftApplication>(dbSetAccessor), IDraftApplicationService
    {
    }
}
