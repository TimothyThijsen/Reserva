using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ServiceClasses
{
    public class UserManager
    {
        IUserDAL userDAL;
        public UserManager(IUserDAL userDAL) 
        { 
            this.userDAL = userDAL;
        }

        public void AddUser(User user)
        {
            List<Member> members = GetAllMembers();
            
            if (members.Find(u => u.Email == user.Email) != null)
            {
                throw new ValidationException($"Email is already in use!");
            }
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);

            userDAL.AddUser(user);
        }

        public void RemoveMember(int id)
        {
            userDAL.RemoveUser(id);
        }
        public User GetMember(int id)
        {
            return userDAL.GetUser(id);
        }

        public List<Member> GetAllMembers()
        {
            return userDAL.GetAllMembers();
        }
        public List<Employee> GetAllEmployees()
        {
            return userDAL.GetAllEmployees();
        }
        public User Login(string email, string password)
        {
            string[] credentials = userDAL.GetCredentials(email.ToLower());
            if (credentials[0] == null)
            {
                throw new Exception("No user found with that email");
            }
            User user;
            if (BCrypt.Net.BCrypt.EnhancedVerify(password, credentials[1]))
            {
                user = GetMember(Convert.ToInt32(credentials[0]));
            }
            else
            {
                throw new Exception("Incorrect password");
            }
            return user;

        }
    }
}
