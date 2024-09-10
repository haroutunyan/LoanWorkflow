using LoanWorkflow.Core.Enums;

namespace LoanWorkflow.Api.Models.Personallnfo.Acts
{
    public record ActMainResponse : MainPageResponse
    {
        public MaritalStatus MaritalStatus { get; set; }
        public byte MarriageCount { get; set; }
        public byte ChildrenCount { get; set; }
        public string SpouseFullName {  get; set; }
        public DateOnly SpouseBirthDate { get; set; }
        public string SpouseSsn { get; set; }
    }
}
