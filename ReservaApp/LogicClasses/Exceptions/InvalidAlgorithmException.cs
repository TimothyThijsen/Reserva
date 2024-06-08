using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public class InvalidAlgorithmException : Exception
    {
        private static readonly string defaultMessage = "Invalid algorithm type";
        public InvalidAlgorithmException() : base(defaultMessage) { }
        public InvalidAlgorithmException(string message) : base(message) { }
    }
}
