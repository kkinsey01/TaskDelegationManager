namespace TaskDelegationAPI.Middleware
{
    public class TaskDelegationException : Exception
    {
        public TaskDelegationException(string message) : base(message) 
        {
        }
    }
}
