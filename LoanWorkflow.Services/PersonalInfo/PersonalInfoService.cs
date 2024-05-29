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
            return new PersonalInfoDTO
            {
                Avv = (await ekengService.GetAvvData(ssn)).Result.FirstOrDefault(),
                Acra = acraService.GetAcraData(),
                Acts = (await ekengService.GetCivilResult(ssn)).Result,
                Ces = (await ekengService.GetCesData(ssn)).Result,
                BusinessRegister = (await ekengService.GetBusinessRegisterData(ssn)).Result,
                TaxInfo = (await ekengService.GetTaxData(ssn)).TaxPayersInfo,
                Vehicles = (await ekengService.GetVehicleData(ssn)).Result
            };
        }
    }
}
