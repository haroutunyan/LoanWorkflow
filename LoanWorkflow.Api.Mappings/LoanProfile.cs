using AutoMapper;
using LoanWorkflow.Api.Models.File.Response;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.DAL.Entities.Loan;

namespace LoanWorkflow.Api.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {

            CreateMap<LoanSetting, LoanSettingDTO>();
            CreateMap<LoanProductSetting, LoanProductSettingDTO>();
            CreateMap<LoanProductType, LoanProductTypeDTO>();
            CreateMap<LoanType, ChildLoanTypesDTO>();
            CreateMap<LoanType, LoanTypesResponse>();
             //   .ForMember(d => d.Childs, opt => opt.MapFrom(s => s));

        }
    }
}
