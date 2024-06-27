namespace SoldierFit.Core.Exceptions
{
    public class AlreadyJoinedException : Exception
    {
        public AlreadyJoinedException()
        {
        }

        public AlreadyJoinedException(string message)
            : base(message) 
        { 
        }
        public AlreadyJoinedException(string message, Exception innerException)
            : base(message, innerException) 
        {
        }
    }
}
