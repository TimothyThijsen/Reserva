using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Employee : User
    {
        decimal salary;
        string phoneNumber;
        public decimal Salary { get { return salary; } }
        public string PhoneNUmber { get { return phoneNumber; } }
        public Employee(string firstName, string lastName, string email, DateOnly dateOfBirth, string password, decimal salary, string phoneNumber) : base(firstName, lastName, email, dateOfBirth, password)
        {
            this.salary = salary;
            this.phoneNumber = phoneNumber;
        }
		public Employee(int id, string firstName, string lastName, string email, DateOnly dateOfBirth, string password, decimal salary, string phoneNumber) : base(id, firstName, lastName, email, dateOfBirth, password)
		{
            this.salary = salary;
            this.phoneNumber = phoneNumber;
		}
	}
}
