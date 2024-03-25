using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public abstract class User
    {
        int? id;
        int age;
        string firstName, lastName, email; 
        string? password;

        public int? Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string? Password { get { return password; } set { password = value; } }
        public int Age {  get { return age; } }
        public User(string firstName, string lastName, string email, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.age = age;
        }
        public User(int id, string firstName, string lastName, string email, int age) : this(firstName, lastName,email,age)
        {
            this.id = id;
        }
    }
}
