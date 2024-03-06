using AutoMapper;
using LoanWorkflow.Api.Models.File.Response;

namespace LoanWorkflow.Api.Mappings
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<DAL.Entities.File.File, FileInfoResponse>()
                .ForMember(e => e.DocTypeName, d => d.MapFrom(o => o.DocType.Name));
        }
    }
}
