namespace LoanWorkflow.Api.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AllowNotValidAttribute : Attribute
    {

    }
}
