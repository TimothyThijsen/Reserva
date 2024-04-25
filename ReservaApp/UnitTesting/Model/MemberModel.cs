using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Model
{
    public class MemberModel : IMemberModel
    {
        public int Id { get; set; } 
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public MemberType Role { get; set; }
        public MemberModel() { }
        public MemberModel(int id, string firstName, string lastName, string email, int age, MemberType memberType, string password) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Role = memberType;
            Password = password;
        }
    }
}
