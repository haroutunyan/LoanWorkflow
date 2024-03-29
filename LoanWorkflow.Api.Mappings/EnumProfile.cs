using AutoMapper;
using LoanWorkflow.Api.Models.Enum;
using LoanWorkflow.Api.Models.File.Response;
using LoanWorkflow.DAL.Entities.File;

namespace LoanWorkflow.Api.Mappings
{
    public class EnumProfile : Profile
    {
        public EnumProfile()
        {
            CreateMap<DocType, DocTypeDTO>()
                .ForMember(s=>s.Id,d=>d.MapFrom(s=>(int)s.Id));
        }
    }
}
