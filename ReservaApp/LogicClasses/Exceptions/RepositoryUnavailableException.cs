namespace DomainLayer.Exceptions
{
    public class RepositoryUnavailableException : Exception
    {
        private static readonly string defaultMessage = "Unable to reach database";
        public RepositoryUnavailableException() : base(defaultMessage) { }
        public RepositoryUnavailableException(string message) : base(message) { }
    }
}
