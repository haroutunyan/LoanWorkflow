using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.Personallnfo;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.Core.Helpers;
using LoanWorkflow.DAL.Entities.Clients;
using LoanWorkflow.DAL.Entities.Loan;
using LoanWorkflow.DAL.Entities.PersonalInfo;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.PersonalInfo;
using LoanWorkflow.Services.Interfaces.Clients;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Controllers
{
    public class ApplicantController(
        ApiContext apiContext,
        IPersonalInfoService personalInfoService,
        IApplicantPersonalInfoService applicantPersonalInfoService)
        : ApiControllerBase(apiContext)
    {
        [HttpPost]
        public async Task<ApiResponse<PersonalInfoDTO>> AddApplicant(SSNRequest request)
        {
            var data = await personalInfoService.GetAllPersonalInfos(request.SSN);
            var document = data.Avv.AvvDocuments.Document.FirstOrDefault(e => e.DocumentStatus == "PRIMARY_VALID")
                ?? throw new ClientDoesNotHavePrimaryDocumentException();

            var address = data.Avv.AvvAddresses.Address.FirstOrDefault(e => e.RegistrationData.RegistrationType == "CURRENT");
            if (address is null)
                throw new Exception();

            var acts = ApiContext.Mapper.Map<ICollection<ECivilData>>(data.Acts);
            var dataList = new List<PersonalInfoBase>
            {
                ApiContext.Mapper.Map<AvvData>(data.Avv),
                ApiContext.Mapper.Map<AcraData>(data.Acra),
                new CesData
                {
                    Inquests = ApiContext.Mapper.Map<ICollection<EInquest>>(data.Ces)
                },
                new VehicleData
                {
                    Vehicles = ApiContext.Mapper.Map<ICollection<EVehicle>>(data.Vehicles)
                },
                new TaxData
                {
                    TaxPayerInfo = ApiContext.Mapper.Map<ICollection<TaxPayerInfo>>(data.TaxInfo)
                }
            };

            foreach (var act in acts)
                dataList.Add(act);

            // var incomes
            var client = new Client
            {
                SSN = request.SSN,
                LastName = document.Person.EnglishLastName,
                FirstName = document.Person.EnglishFirstName,
                BirthDate = document.Person.BirthDate.Value,
                Document = document.DocumentNumber,
                DocIssuedDate = document.PassportData.IssuanceDate.Value,
                DocIssuer = document.DocumentDepartment,
                DocValidityDate = document.PassportData.ValidityDate.Value,
                Gender = EnumHelper.GetEnumValueByDescription<Gender>(document.Person.Genus),
                MiddleName = document.Person.EnglishPatronymicName,
                Address = ToAddressLine(address.RegistrationAddress),
                ActualAddress = ToAddressLine(address.RegistrationAddress),
                Email = string.Empty,
                PhoneNumber = string.Empty,
                SecondPhoneNumber = string.Empty
            };

            var applicant = new Applicant
            {
                Client = client,
                Type = ClientType.Other,
            };

            var applicantPersonalInfos = dataList
                .Where(e => e is not null)
                .Select(e => new ApplicantPersonalInfo
                {
                    PersonalInfo = e,
                    Applicant = applicant
                })
                .ToList();

            await applicantPersonalInfoService.AddRange(applicantPersonalInfos);
            await SaveChangesAsync(UserContext.UserId);

            data.ApplicantId = applicant.Id;

            return new ApiResponse<PersonalInfoDTO>(data);
        }

        private static string ToAddressLine(RegistrationAddressDTO registrationAddress)
        {
            return $"{registrationAddress.Apartment}" +
                $" {registrationAddress.Building}" +
                $" {registrationAddress.BuildingType} " +
                $"{registrationAddress.Residence}" +
                $" {registrationAddress.Region}";
        }

        //private static ICollection<Income> GetCurrentIncomes(TaxPayersInfoDTO tax)
        //{
        //    var incomes = new List<Income>();
        //    foreach (var taxPayer in tax.TaxPayerInfo)
        //    {
        //        var currentIncome = taxPayer.PersonInfoPeriods.PersonInfoPeriod.FirstOrDefault(e => (DateTime.UtcNow - e.Date).TotalDays < 93);
        //        if (currentIncome is not null)
        //            incomes.Add(new Income
        //            {

        //            });
        //    }
        //}
    }
}
