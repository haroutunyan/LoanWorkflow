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
        Task<AvvResult> GetAvvData(string ssn);
        Task<PhysicalPersonBusinessDTO> GetBusinessRegisterData(string ssn);
        Task<IEnumerable<ECivilAct>> GetCivilResult(string ssn, string firstName, string lastName);
        Task<IEnumerable<EVehicleDTO>> GetVehicleData(string ssn);
        Task<IEnumerable<EInquestDTO>> GetCesData(string ssn);
        Task<IEnumerable<TaxPayerInfoDTO>> GetTaxData(string ssn, DateTime start, DateTime end);
    }
}
