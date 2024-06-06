using LoanWorkflow.Core.Helpers;
using LoanWorkflow.Services.DTO;
using LoanWorkflow.Services.DTO.Ekeng;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.DTO.Ekeng.TaxInfo;
using LoanWorkflow.Services.Interfaces.Ekeng;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.Ekeng
{
    public class EkengService(
        HttpClient httpClient,
        IConfiguration config) : IEkengService
    {
        public async Task<AvvResponse> GetAvvData(string ssn)
        {
            return await httpClient.PostUrlEncoded<RequestPsn, AvvResponse>("api/avv/search", new RequestPsn { SSN = ssn });
        }

        public async Task<PhysicalPersonBusinessResult> GetBusinessRegisterData(string ssn)
        {
            return await httpClient.PostJson<BusinesRegisterRequest, PhysicalPersonBusinessResult>("api/eregister/json_rpc", new BusinesRegisterRequest
            {
                Id = 1,
                Method = "person_info",
                JsonRPC = "2.0",
                Params = new RequestSsn { SSN = ssn }
            });
        }

        public async Task<CesResult> GetCesData(string ssn)
        {
            return await httpClient.PostUrlEncoded<RequestSsn, CesResult>("api/ces/get_debtor_info", new RequestSsn { SSN = ssn });
        }

        public async Task<CivilResult> GetCivilResult(string ssn, string firstName, string lastName)
        {
            return await httpClient.PostUrlEncoded<CivilRequest, CivilResult>("api/ecivil/get_act",
                new CivilRequest
                {
                    SSN = ssn,
                    FirstName = firstName,
                    LastName = lastName
                });
        }

        public async Task<VehiclesResult> GetVehicleData(string ssn)
        {
            return await httpClient.PostUrlEncoded<RequestPsn, VehiclesResult>("api/epolice/get_vehicle_info", new RequestPsn { SSN = ssn });
        }

        public async Task<TaxInfoResult> GetTaxData(string ssn, DateTime start, DateTime end)
        {
            return await httpClient.PostXml<TaxIncomeRequest, TaxInfoResult>("api/tax/ssn",
                new TaxIncomeRequest
                {
                    SSN = ssn,
                    EndDate = end.ToString("yyyy-MM-dd"),
                    StartDate = start.ToString("yyyy-MM-dd")
                });
        }
    }
}
