using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;

namespace LoanWorkflow.Services.Interfaces.Ekeng
{
    public interface IEkengService
    {
        Task<AvvResponse> GetAvvData(string ssn);
        Task<PhysicalPersonBusinessResult> GetBusinessRegisterData(string ssn);
        Task<CivilResult> GetCivilResult(string ssn);
        Task<VehiclesResult> GetVehicleData(string ssn);
        Task<CesResult> GetCesData(string ssn);
    }
}
