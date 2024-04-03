using LoanWorkflow.Services.DTO.Ekeng;

namespace LoanWorkflow.Services.Interfaces.Ekeng
{
    public interface IEkengService
    {
        Task<AvvResult> GetAvvData(string ssn);
    }
}
