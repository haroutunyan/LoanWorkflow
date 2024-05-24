using LoanWorkflow.Api.Models.Clients;
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
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "avv.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<AvvResponse>(data));
        }

        public async Task<PhysicalPersonBusinessResult> GetBusinessRegisterData(string ssn)
        {
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "businessregister.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<PhysicalPersonBusinessResult>(data));
        }

        public async Task<CesResult> GetCesData(string ssn)
        {
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "ces.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<CesResult>(data));
        }

        public async Task<CivilResult> GetCivilResult(string ssn)
        {
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "ecivil.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<CivilResult>(data));
        }

        public async Task<VehiclesResult> GetVehicleData(string ssn)
        {
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "vehicleinfo.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<VehiclesResult>(data));
        }

        public async Task<TaxInfoResult> GetTaxData(string ssn)
        {
            var data = File.ReadAllText(Path.Combine(config["PersonalInfo"], "taxmonthly.txt"));
            return await Task.FromResult(JsonConvert.DeserializeObject<TaxInfoResult>(data));
        }

        public async Task<ClientData> GetClientData(string ssn)
        {
            var client = config.GetSection("ClientData").Get<IList<ClientData>>();
            return client.FirstOrDefault(p => p.SSN == ssn);
        }
    }
}
