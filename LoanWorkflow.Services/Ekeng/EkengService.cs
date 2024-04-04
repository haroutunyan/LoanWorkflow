using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.Interfaces.Ekeng;
using Newtonsoft.Json;

namespace LoanWorkflow.Services.Ekeng
{
    public class EkengService(
        HttpClient httpClient) : IEkengService
    {
        public async Task<AvvResponse> GetAvvData(string ssn)
        {
            var data = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\avv.txt");
            return await Task.FromResult(JsonConvert.DeserializeObject<AvvResponse>(data));
        }

        public async Task<PhysicalPersonBusinessResult> GetBusinessRegisterData(string ssn)
        {
            var data = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\businessregister.txt");
            return await Task.FromResult(JsonConvert.DeserializeObject<PhysicalPersonBusinessResult>(data));
        }

        public async Task<CesResult> GetCesData(string ssn)
        {
            var data = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\ces.txt");
            return await Task.FromResult(JsonConvert.DeserializeObject<CesResult>(data));
        }

        public async Task<CivilResult> GetCivilResult(string ssn)
        {
            var data = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\ecivil.txt");
            return await Task.FromResult(JsonConvert.DeserializeObject<CivilResult>(data));
        }

        public async Task<VehiclesResult> GetVehicleData(string ssn)
        {
            var data = File.ReadAllText("C:\\Users\\User\\Downloads\\Telegram Desktop\\vehicleinfo.txt");
            return await Task.FromResult(JsonConvert.DeserializeObject<VehiclesResult>(data));
        }
    }
}
