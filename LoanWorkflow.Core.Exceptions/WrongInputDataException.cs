namespace LoanWorkflow.Core.Exceptions
{
    public class WrongInputDataException : LoanWorkflowException
    {
        public WrongInputDataException()
        {
            
        }

        public WrongInputDataException(string message) : base(message)
        {
            
        }
    }
}
