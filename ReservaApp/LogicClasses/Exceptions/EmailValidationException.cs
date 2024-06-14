namespace DomainLayer.Exceptions
{
    public class EmailValidationException : Exception
    {
        private static readonly string defaultMessage = "Email is already in use";
        public EmailValidationException() : base(defaultMessage) { }
        public EmailValidationException(string message) : base(message) { }
    }
}
