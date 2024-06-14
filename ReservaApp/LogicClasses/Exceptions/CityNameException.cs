namespace DomainLayer.Exceptions
{
    public class CityNameException : Exception
    {
        private static readonly string defaultMessage = "Location name already in use!";
        public CityNameException() : base(defaultMessage) { }
        public CityNameException(string message) : base(message) { }
    }
}
