namespace API.Exceptions
{

	public class EmploymentDateOutOfRangeException : Exception
	{
		public EmploymentDateOutOfRangeException(string message) : base(message) { }
	}
}
