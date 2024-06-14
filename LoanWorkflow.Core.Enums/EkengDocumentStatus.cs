using System.ComponentModel;

namespace LoanWorkflow.Core.Enums
{
    public enum EkengDocumentStatus
    {
        [Description("PRIMARY_VALID")]
        PrimaryValid = 1,

        [Description("VALID")]
        Valid = 2,

        [Description("INVALID")]
        Invalid = 3
    }
}
