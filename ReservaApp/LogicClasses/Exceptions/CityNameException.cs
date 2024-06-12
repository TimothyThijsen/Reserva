using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public class CityNameException : Exception
    {
        private static readonly string defaultMessage = "Location name already in use!";
        public CityNameException() : base(defaultMessage) { }
        public CityNameException(string message) : base(message) { }
    }
}
