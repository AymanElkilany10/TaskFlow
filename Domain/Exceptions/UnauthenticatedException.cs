namespace TaskFlow.Domain.Exceptions
{
    public class UnauthenticatedException : Exception
    {
        public UnauthenticatedException() : base("Unauthenticated access.")
        {
        }
    }
}
