namespace LoanWorkflow.Services.DTO.Ekeng.AVV
{
    public record AvvAddressDTO
    {
        public RegistrationAddressDTO RegistrationAddress { get; init; }
        public ResidenceDocumentDTO ResidenceDocument { get; init; }
        public RegistrationDataDTO RegistrationData { get; init; }
    }
}
