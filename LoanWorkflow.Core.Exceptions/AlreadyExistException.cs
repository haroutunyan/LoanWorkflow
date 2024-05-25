namespace LoanWorkflow.Core.Exceptions
{
    public class AlreadyExistException : LoanWorkflowException
    {
        public AlreadyExistException()
        {
            
        }

        public AlreadyExistException(string message) : base(message)
        {
            
        }
    }
}
