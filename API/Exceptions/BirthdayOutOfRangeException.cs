namespace API.Exceptions
{
    public class BirthdayOutOfRangeException : Exception
    {
        public BirthdayOutOfRangeException(string? message) : base(message)
        {
        }
    }
}