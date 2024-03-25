using LoanWorkflow.Services.DTO.Ekeng.AVV;

namespace LoanWorkflow.Services.Interfaces.Ekeng
{
    public interface IEkengService
    {
        Task<AvvResult> GetAvvData(string ssn);
    }
}
