using Azure.Core;
using LoanWorkflow.Core.Enums;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.Services.DTO.Acra;
using LoanWorkflow.Services.DTO.PersonalInfo;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Ekeng;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class PersonalInfoService(
        IAcraService acraService,
        IEkengService ekengService)
        : IPersonalInfoService
    {
        public async Task<PersonalInfoDTO> GetAllPersonalInfos(string ssn)
        {
            var avv = await ekengService.GetAvvData(ssn)
                ?? throw new EkengException();

            var passport = avv.AvvDocuments.Document.FirstOrDefault(e =>
                (e.DocumentType == "NON_BIOMETRIC_PASSPORT" || e.DocumentType == "BIOMETRIC_PASSPORT")
                && e.DocumentStatus != "INVALID");
            var IdCard = avv.AvvDocuments.Document.FirstOrDefault(e =>
                e.DocumentType == "ID_CARD"
                && e.DocumentStatus != "INVALID");

            var firstDoc = passport ?? IdCard;
            //var acra = acraService.GetAcraData(new AcraRequest
            //{
            //    ACRAReportType = ACRAReportTypes.Full,
            //    BirthDate = firstDoc.Person.BirthDate.Value,
            //    FirstName = firstDoc.Person.FirstName,
            //    LastName = firstDoc.Person.LastName,
            //    SocialCard = ssn,
            //    RequestTarget = RequestTarget.NewLoanAppTest,
            //    RequestType = AvhRequestType.Sole,
            //    UsageRange = UsageRange.OtherTest,
            //    Passport = passport?.DocumentNumber,
            //    IdCard = IdCard?.DocumentNumber
            //}, true);
            var acts = ekengService.GetCivilResult(ssn, firstDoc.Person.FirstName, firstDoc.Person.LastName);
            var ces = ekengService.GetCesData(ssn);
            var businessRegister = ekengService.GetBusinessRegisterData(ssn);
            var tax = ekengService.GetTaxData(ssn, DateTime.UtcNow.AddYears(-1), DateTime.UtcNow);
            var vehicles = ekengService.GetVehicleData(ssn);

            await Task.WhenAll(
                //acra,
                acts, ces, businessRegister, tax, vehicles);

            return new PersonalInfoDTO
            {
                Avv = avv,
               // Acra = await acra,
                Acts = await acts,
                Ces = await ces,
                BusinessRegister = await businessRegister,
                //TaxInfo = await tax,
                Vehicles = await vehicles
            };
        }
    }
}
