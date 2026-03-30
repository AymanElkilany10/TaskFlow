namespace TaskFlow.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Unauthorized access.")
        {
        }
    }
}
