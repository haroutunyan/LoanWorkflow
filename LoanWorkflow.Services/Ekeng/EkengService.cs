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

namespace LoanWorkflow.Services.Ekeng
{
    public class EkengService(
        HttpClient httpClient) 
        : IEkengService
    {
        public async Task<AvvResult> GetAvvData(string ssn)
        {
            var result = await httpClient.PostUrlEncoded<RequestPsn, AvvResponse>("api/avv/search", new RequestPsn { SSN = ssn });
            if (result is null || result.Status != "ok" || result.Result is null || result.Result.Count == 0)
                return null;

            return result.Result.FirstOrDefault();
        }

        public async Task<PhysicalPersonBusinessDTO> GetBusinessRegisterData(string ssn)
        {
            var result = await httpClient.PostJson<BusinesRegisterRequest, PhysicalPersonBusinessResult>("api/eregister/json_rpc", new BusinesRegisterRequest
            {
                Id = 1,
                Method = "person_info",
                JsonRPC = "2.0",
                Params = new RequestSsn { SSN = ssn }
            });
            if (result is null || result.Status != "ok")
                return null;

            return result.Result;
        }

        public async Task<IEnumerable<EInquestDTO>> GetCesData(string ssn)
        {
            var result = await httpClient.PostUrlEncoded<RequestSsn, CesResult>("api/ces/get_debtor_info", new RequestSsn { SSN = ssn });
            if (result is null || result.Status != "ok")
                return null;

            return result.Result;
        }

        public async Task<IEnumerable<ECivilAct>> GetCivilResult(string ssn, string firstName, string lastName)
        {
            var result = await httpClient.PostUrlEncoded<CivilRequest, CivilResult>("api/ecivil/get_act",
                new CivilRequest
                {
                    SSN = ssn,
                    FirstName = firstName,
                    LastName = lastName
                });
            if (result is null || result.Status != "ok")
                return null;

            return result.Result;
        }

        public async Task<IEnumerable<EVehicleDTO>> GetVehicleData(string ssn)
        {
            var result = await httpClient.PostUrlEncoded<RequestPsn, VehiclesResult>("api/epolice/get_vehicle_info", new RequestPsn { SSN = ssn });
            if (result is null || result.Status != "ok")
                return null;

            return result.Result;
        }

        public async Task<IEnumerable<TaxPayerInfoDTO>> GetTaxData(string ssn, DateTime start, DateTime end)
        {
            var result = await httpClient.PostXml<TaxIncomeRequest, TaxInfoResult>("api/tax/ssn",
                new TaxIncomeRequest
                {
                    SSN = ssn,
                    EndDate = end.ToString("yyyy-MM-dd"),
                    StartDate = start.ToString("yyyy-MM-dd")
                });
            if (result is null || result.ResponseStatus.StatusText != "ok" || result.TaxPayersInfo is null)
                return null;

            return result.TaxPayersInfo.TaxPayerInfo;
        }
    }
}
