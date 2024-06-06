using Azure.Core;
using LoanWorkflow.Services.DTO.PersonalInfo;
using LoanWorkflow.Services.Interfaces.Acra;
using LoanWorkflow.Services.Interfaces.Ekeng;
using LoanWorkflow.Services.Interfaces.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.PersonalInfo
{
    public class PersonalInfoService(
        IAcraService acraService,
        IEkengService ekengService) : IPersonalInfoService
    {
        public async Task<PersonalInfoDTO> GetAllPersonalInfos(string ssn)
        {
            var avv = (await ekengService.GetAvvData(ssn)).Result.FirstOrDefault();
            var firstDoc = avv.AvvDocuments.Document.FirstOrDefault();
            return new PersonalInfoDTO
            {
                Avv = avv,
                Acra = acraService.GetAcraData(),
                Acts = (await ekengService.GetCivilResult(ssn, firstDoc.Person.FirstName, firstDoc.Person.LastName)).Result,
                Ces = (await ekengService.GetCesData(ssn)).Result,
                BusinessRegister = (await ekengService.GetBusinessRegisterData(ssn)).Result,
                TaxInfo = (await ekengService.GetTaxData(ssn, DateTime.UtcNow.AddYears(-1), DateTime.UtcNow)).TaxPayersInfo,
                Vehicles = (await ekengService.GetVehicleData(ssn)).Result
            };
        }
    }
}
