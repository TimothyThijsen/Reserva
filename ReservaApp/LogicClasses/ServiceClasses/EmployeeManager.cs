using DomainLayer.Exceptions;
using DomainLayer.Interfaces;
using Models;
using System.ComponentModel.DataAnnotations;


namespace DomainLayer.ServiceClasses
{
    public class EmployeeManager
    {
        IUserDAL userDAL;
        public EmployeeManager(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public void AddEmployee(Employee employee)
        {
            if (!ObjectValidator.HasNoEmptyFields(employee))
            {
                throw new ValidationException("Incomplete member model");
            }

            //Member member = memberModel.ToLogicLayer();
            //member.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(member.Password);
            userDAL.AddUser(employee);
            //.AddUser(member);
        }

        public void RemoveEmployee(int id)
        {
            userDAL.RemoveUser(id);
        }
        public Employee GetEmployee(int id)
        {
            return (Employee)userDAL.GetUser(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return userDAL.GetAllUser().Select(x => (Employee)x).ToList();
        }
        public Employee GetEmployeeByEmail(string email)
        {
            return (Employee)userDAL.GetUserByEmail(email);
        }
        public Employee Login(string email, string password)
        {
            Employee member = GetEmployeeByEmail(email);
            if (member == null)
            {
                throw new CredentialException();
            }
            if (!BCrypt.Net.BCrypt.EnhancedVerify(password, member.Password))
            {
                throw new CredentialException();
            }
            return member;
        }
    }
}
