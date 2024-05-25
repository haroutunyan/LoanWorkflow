using AutoMapper;
using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Api.Models.Loan;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.DAL.Entities.Loan;
using Microsoft.Extensions.Configuration;

namespace LoanWorkflow.Api.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanSetting, LoanSettingDTO>();
            CreateMap<LoanProductSetting, LoanProductSettingDTO>();
            CreateMap<LoanProductType, LoanProductTypeDTO>();
            CreateMap<LoanType, ChildLoanTypesDTO>()
                .AfterMap<ChildLoanTypesDTOAction>();
            CreateMap<LoanType, LoanTypesResponse>();

            CreateMap<LoanProductSetting, LoanRepaymentTypesDTO>()
                .AfterMap<LoanRepaymentTypesDTOAction>();

            CreateMap<LoanProductSetting, LoanCurrenciesByRepaymentTypeIdDTO>()
                .AfterMap<LoanCurrenciesByRepaymentTypeIdDTOAction>();

            CreateMap<LoanProductSetting, LoanRepaymentTypesByCurrencyDTO>()
                .AfterMap<LoanRepaymentTypesBYCurrnecyDTOAction>();

            CreateMap<LoanType, LoanTypeInfoResponse>();

            CreateMap<LoanProductSetting, LoanCurrenciesByProductTypeIdDTO>()
              .AfterMap<LoanCurrenciesByProductTypeIdDTOAction>();

            CreateMap<LoanType, ChildLoanTypeShortModel>()
                .AfterMap<LoanTypeToChildLoanTypeShortModelAction>();

            CreateMap<ClientLoans, GetClientLoanApplicationResponseModel>()
                .ForMember(p => p.LoanProductType, otp => otp.MapFrom(src => src.LoanProductTypeId))
                .ForMember(p => p.LoanType, otp => otp.MapFrom(src => src.LoanTypeId));
        }

        
        public class ChildLoanTypesDTOAction : IMappingAction<LoanType, ChildLoanTypesDTO>
        {
            private readonly IConfiguration _configuration;

            public ChildLoanTypesDTOAction(IConfiguration configuration)
            {
                _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            }

            public void Process(LoanType source, ChildLoanTypesDTO destination, ResolutionContext context)
            {
                destination.Img = source?.File?.Path is not null ? $"{_configuration.GetSection("FileDisplayPath").Value ?? string.Empty}{source?.File?.Path}" : null;
            }
        }

        public class LoanRepaymentTypesDTOAction : IMappingAction<LoanProductSetting, LoanRepaymentTypesDTO>
        {
            public void Process(LoanProductSetting source, LoanRepaymentTypesDTO destination, ResolutionContext context)
            {
                destination.Id = (short)source.RepaymentType;
                destination.Name = (short)source.RepaymentType switch
                {
                    1 => "Անուիտետ",
                    2 => "Զսպանակաձև",
                    3 => "Ժամկետի վերջում",
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public class LoanCurrenciesByProductTypeIdDTOAction : IMappingAction<LoanProductSetting, LoanCurrenciesByProductTypeIdDTO>
        {
            public void Process(LoanProductSetting source, LoanCurrenciesByProductTypeIdDTO destination, ResolutionContext context)
            {
                destination.ProductTypeId = (short)source.ProductTypeId;
                destination.Currency = source.LoanSetting.Currency;
            }
        }

        public class LoanCurrenciesByRepaymentTypeIdDTOAction : IMappingAction<LoanProductSetting, LoanCurrenciesByRepaymentTypeIdDTO>
        {
            public void Process(LoanProductSetting source, LoanCurrenciesByRepaymentTypeIdDTO destination, ResolutionContext context)
            {
                destination.ProductSettingId = source.Id;
                destination.Currency = source.LoanSetting.Currency;
            }
        }

        public class LoanRepaymentTypesBYCurrnecyDTOAction : IMappingAction<LoanProductSetting, LoanRepaymentTypesByCurrencyDTO>
        {
            public void Process(LoanProductSetting source, LoanRepaymentTypesByCurrencyDTO destination, ResolutionContext context)
            {
                destination.Id = (short)source.RepaymentType;
                destination.ProductSettingId = source.Id;
                destination.Name = (short)source.RepaymentType switch
                {
                    1 => "Անուիտետ",
                    2 => "Զսպանակաձև",
                    3 => "Ժամկետի վերջում",
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public class LoanTypeToChildLoanTypeShortModelAction(IConfiguration configuration) : IMappingAction<LoanType, ChildLoanTypeShortModel>
        {
            private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            public void Process(LoanType source, ChildLoanTypeShortModel destination, ResolutionContext context)
            {
                destination.Img = source?.File?.Path is not null ? 
                    $"{_configuration.GetSection("FileDisplayPath").Value ?? string.Empty}{source?.File?.Path}" : null;
            }
        }
    }
}
