using Enums;

namespace DomainLayer
{
    public class Employee : User
    {
        decimal salary;
        string phoneNumber;
        EmployeeRole role;
        public decimal Salary { get { return salary; } }
        public string PhoneNUmber { get { return phoneNumber; } }
        public EmployeeRole Role { get { return role; } }
        public Employee(string firstName, string lastName, string email, DateOnly dateOfBirth, string password, decimal salary, string phoneNumber, EmployeeRole role) : base(firstName, lastName, email, dateOfBirth, password)
        {
            this.salary = salary;
            this.phoneNumber = phoneNumber;
            this.role = role;
        }
        public Employee(int id, string firstName, string lastName, string email, DateOnly dateOfBirth, string password, decimal salary, string phoneNumber, EmployeeRole role) : base(id, firstName, lastName, email, dateOfBirth, password)
        {
            this.salary = salary;
            this.phoneNumber = phoneNumber;
            this.role = role;
        }
    }
}
