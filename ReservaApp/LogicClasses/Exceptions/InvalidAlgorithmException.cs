namespace DomainLayer.Exceptions
{
    public class InvalidAlgorithmException : Exception
    {
        private static readonly string defaultMessage = "Invalid algorithm type";
        public InvalidAlgorithmException() : base(defaultMessage) { }
        public InvalidAlgorithmException(string message) : base(message) { }
    }
}
