using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Employee : User
    {
        public Employee(string firstName, string lastName, string email, DateOnly dateOfBirth, string password) : base(firstName, lastName, email, dateOfBirth, password)
        {
        }
    }
}
