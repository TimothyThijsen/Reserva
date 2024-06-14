namespace DomainLayer.Exceptions
{
    public class CredentialException : Exception
    {
        private static readonly string defaultMessage = "Incorrect login detail";
        public CredentialException() : base(defaultMessage) { }
        public CredentialException(string message) : base(message) { }

    }
}
