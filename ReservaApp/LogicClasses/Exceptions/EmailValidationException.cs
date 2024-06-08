using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public class EmailValidationException : Exception
    {
        private static readonly string defaultMessage = "Email is already in use";
        public EmailValidationException() : base(defaultMessage) { }
        public EmailValidationException(string message) : base(message) { }
    }
}
