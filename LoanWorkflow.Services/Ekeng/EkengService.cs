using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.Interfaces.Ekeng;

namespace LoanWorkflow.Services.Ekeng
{
    public class EkengService(
        HttpClient httpClient) : IEkengService
    {
        public Task<AvvResult> GetAvvData(string ssn)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessRegisterResult> GetBusinessRegisterData(string ssn)
        {
            throw new NotImplementedException();
        }

        public Task<CesResult> GetCesData(string ssn)
        {
            throw new NotImplementedException();
        }

        public Task<CivilResult> GetCivilResult(string ssn)
        {
            throw new NotImplementedException();
        }

        public Task<VehiclesResult> GetVehicleData(string ssn)
        {
            throw new NotImplementedException();
        }
    }
}
