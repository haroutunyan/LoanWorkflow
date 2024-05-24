using AutoMapper;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.Services.Abstractions;
using LoanWorkflow.Services.Interfaces.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanWorkflow.Services.Loan
{
    public class LoanTypeService(IDbSetAccessor<LoanType> dbSetAccessor, IMapper mapper)
        : Service<LoanType>(dbSetAccessor), ILoanTypeService
    {
        public async Task<List<LoanType>> GetAllLoanTypes()
        {
            return await Repository
                    .Include(x=>x.Childs)
                        .ThenInclude(x => x.LoanProductTypes)
                        .ThenInclude(x => x.LoanProductSettings)
                        .ThenInclude(x => x.LoanSetting)
                    .Include(x=>x.Childs)
                        .ThenInclude(x=>x.File)
                    .Where(x => x.ParentId == null)
                    .ToListAsync(); 
        }

        public async Task<IList<GetLoanTypeShortResponseModel>> GetLoanTypes()
        {
            var loanTypes = await Repository.Include(p => p.Childs).ThenInclude(x => x.File).Where(x => x.ParentId == null).ToListAsync();
            var shortLoanTypes = loanTypes.Select(p =>

            new GetLoanTypeShortResponseModel
            {
                Name = p.Name,
                IsActive = p.IsActive,
                HasPledge = p.HasPledge,
                Id = p.Id,
                Childs = mapper.Map<List<ChildLoanTypeShortModel>?>(p.Childs)
            }).ToList();

            return shortLoanTypes;
        }
    }
}
