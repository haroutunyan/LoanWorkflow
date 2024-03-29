using AutoMapper;
using LoanWorkflow.Api.Models.File.Response;
using LoanWorkflow.Api.Models.Loan;
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
                destination.Img = source?.File?.Path is not null ? $"{AppDomain.CurrentDomain.BaseDirectory}{_configuration.GetSection("FilePath").Value ?? string.Empty}\\{source?.File?.Path}" : null;
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

        public class LoanCurrenciesByRepaymentTypeIdDTOAction : IMappingAction<LoanProductSetting, LoanCurrenciesByRepaymentTypeIdDTO>
        {
            public void Process(LoanProductSetting source, LoanCurrenciesByRepaymentTypeIdDTO destination, ResolutionContext context)
            {
                destination.ProductSettingId = source.Id;
                destination.Currency = source.LoanSetting.Currency;
            }
        }

    }
}
