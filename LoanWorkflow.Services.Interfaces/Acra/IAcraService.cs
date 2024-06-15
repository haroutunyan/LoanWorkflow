using LoanWorkflow.Services.DTO.Acra;

namespace LoanWorkflow.Services.Interfaces.Acra
{
    public interface IAcraService
    {
        Task<AcraResult> GetAcraData(AcraRequest model, bool isMonitoring);
    }
}
