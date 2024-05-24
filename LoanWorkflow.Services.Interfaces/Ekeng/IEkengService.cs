using LoanWorkflow.Api.Models.Clients;
using LoanWorkflow.Services.DTO.Ekeng.AVV;
using LoanWorkflow.Services.DTO.Ekeng.BusinessRegister;
using LoanWorkflow.Services.DTO.Ekeng.Ces;
using LoanWorkflow.Services.DTO.Ekeng.ECivil;
using LoanWorkflow.Services.DTO.Ekeng.Police;
using LoanWorkflow.Services.DTO.Ekeng.TaxInfo;

namespace LoanWorkflow.Services.Interfaces.Ekeng
{
    public interface IEkengService
    {
        Task<AvvResponse> GetAvvData(string ssn);
        Task<PhysicalPersonBusinessResult> GetBusinessRegisterData(string ssn);
        Task<CivilResult> GetCivilResult(string ssn);
        Task<VehiclesResult> GetVehicleData(string ssn);
        Task<CesResult> GetCesData(string ssn);
        Task<TaxInfoResult> GetTaxData(string ssn);
        Task<ClientData> GetClientData(string ssn);
    }
}
