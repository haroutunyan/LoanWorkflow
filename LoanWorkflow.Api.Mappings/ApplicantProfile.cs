using AutoMapper;
using LoanWorkflow.Api.Models.Personallnfo.Acts;
using LoanWorkflow.Api.Models.Personallnfo.Avv;
using LoanWorkflow.Api.Models.Personallnfo.Ces;
using LoanWorkflow.Api.Models.Personallnfo.Tax;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.DTO.Ekeng.TaxInfo;
namespace LoanWorkflow.Api.Mappings
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile() 
        {
            CreateMap<PersonInfoPeriodDTO, PersonInfoPeriod>();
            CreateMap<PersonInfoDTO, PersonInfo>();
            CreateMap<TaxPayerInfoDTO, TaxPayerInfo>()
                .ForMember(x => x.PersonInfoPeriods, dest => dest.MapFrom(m => m.PersonInfoPeriods.PersonInfoPeriod));

            CreateMap<PersonInfoPeriod, PersonInfoPeriodResponse>();
            CreateMap<PersonInfo, PersonInfoResponse>();
            CreateMap<TaxPayerInfo, TaxDetailedResponse>();

            CreateMap<ECivilAct, ECivilData>();
            CreateMap<ChildDTO, Child>();
            CreateMap<CivilDeathDTO, CivilDeath>();
            CreateMap<CivilPersonDTO, CivilPerson>();
            CreateMap<CivilPersonBaseInfoDTO, CivilPersonBaseInfo>();
            CreateMap<CivilPersonBirthDTO, CivilPersonBirth>();
            CreateMap<CivilPersonResidentDTO, CivilPersonResident>();

            CreateMap<ActDetailedResponse, ECivilData>().ReverseMap();
            CreateMap<ChildResponse, Child>().ReverseMap();
            CreateMap<CivilDeathResponse, CivilDeath>().ReverseMap();
            CreateMap<CivilPersonResponse, CivilPerson>().ReverseMap();
            CreateMap<CivilPersonBaseInfoResponse, CivilPersonBaseInfo>().ReverseMap();
            CreateMap<CivilPersonBirthResponse, CivilPersonBirth>().ReverseMap();
            CreateMap<CivilPersonResidentResponse, CivilPersonResident>().ReverseMap();

            CreateMap<EInquestDTO, EInquest>();

            CreateMap<AvvResult, AvvData>()
                .ForMember(x => x.AvvAddresses, dest => dest.MapFrom(m => m.AvvAddresses.Address))
                .ForMember(x => x.AvvDocuments, dest => dest.MapFrom(m => m.AvvDocuments.Document));
            CreateMap<AvvDocumentDTO, AvvDocument>()
                .ForMember(x => x.PhotoPath, dest => dest.MapFrom(m => m.Photo));
            CreateMap<AvvAddressDTO, AvvAddress>();
            CreateMap<BasicDocumentDTO, BasicDocument>();
            CreateMap<PassportDataDTO, PassportData>();
            CreateMap<AvvPersonDTO, AvvPerson>();
            CreateMap<RegistrationAddressDTO, RegistrationAddress>();
            CreateMap<ResidenceDocumentDTO, ResidenceDocument>();
            CreateMap<RegistrationDataDTO, RegistrationData>();
            CreateMap<CitizenshipDTO, Citizenship>();

            CreateMap<AvvDetailedResponse, AvvData>().ReverseMap();
            CreateMap<AvvDocumentResponse, AvvDocument>().ReverseMap();
            CreateMap<AvvAddressResponse, AvvAddress>().ReverseMap();
            CreateMap<BasicDocumentResponse, BasicDocument>().ReverseMap();
            CreateMap<PassportDataResponse, PassportData>().ReverseMap();
            CreateMap<AvvPersonResponse, AvvPerson>().ReverseMap();
            CreateMap<RegistrationAddressResponse, RegistrationAddress>().ReverseMap();
            CreateMap<ResidenceDocumentResponse, ResidenceDocument>().ReverseMap();
            CreateMap<RegistrationDataResponse, RegistrationData>().ReverseMap();
            CreateMap<CitizenshipResponse, Citizenship>().ReverseMap();

            CreateMap<EVehicleDTO, EVehicle>().ReverseMap();
            CreateMap<LenderDTO, Lender>();
            CreateMap<InsuranceInfoDTO, InsuranceInfo>();
            CreateMap<EPolicePersonBaseDTO, EPolicePersonBase>();

            CreateMap<AcraResult, AcraData>();
            CreateMap<ParticipientDTO, Participient>()
                .ForMember(x => x.Loans, dest => dest.MapFrom(m => m.Loans.Loan))
                .ForMember(x => x.Guarantees, dest => dest.MapFrom(m => m.Guarantees.Guarantee))
                .ForMember(x => x.Requests, dest => dest.MapFrom(m => m.Requests.Request))
                .ForMember(x => x.Interrelated, dest => dest.MapFrom(m => m.InterrelatedData.Interrelated));
            CreateMap<TotalLiabilitiesLoanDTO, TotalLiabilitiesLoan>();
            CreateMap<LoanDTO, Loans>()
                .ForMember(x => x.OutstandingDaysCount, dest => dest.MapFrom(m => m.OutstandingDaysCount.Year));
            CreateMap<GuaranteeDTO, Guarantee>()
                .ForMember(x => x.OutstandingDaysCount, dest => dest.MapFrom(m => m.OutstandingDaysCount.Year));
            CreateMap<CountOfGuaranteesDTO, CountOfLoans>();
            CreateMap<CountOfLoansDTO, CountOfLoans>();
            CreateMap<InterrelatedDTO, Interrelated>()
                .ForMember(x => x.InterrelatedLoans, dest => dest.MapFrom(m => m.InterrelatedLoans.InterrelatedLoan));
            CreateMap<RequestDTO, Request>();
            CreateMap<InterrelatedLoanDTO, InterrelatedLoan>();
            CreateMap<YearDTO, Year>();
            CreateMap<MonthDTO, Month>();
            CreateMap<InterrelatedLoanDTO, InterrelatedLoan>();

            CreateMap<CesDetailedResponse, EInquest>().ReverseMap();
            CreateMap<VehiclesResultResponseModel, EVehicle>().ReverseMap();
            CreateMap<LenderResponse, Lender>().ReverseMap();
            CreateMap<InsuranceInfoResponse, InsuranceInfo>().ReverseMap();
            CreateMap<EPolicePersonBaseResponse, EPolicePersonBase>().ReverseMap();
        }
    }
}
