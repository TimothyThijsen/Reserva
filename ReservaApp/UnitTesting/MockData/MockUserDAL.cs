
using DomainLayer;
using DomainLayer.Interfaces;
using LogicClasses.Interfaces;
using Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace UnitTesting.MockData
{
	public class MockUserDAL : IUserDAL
	{
        private readonly Bogus.Faker faker = new Bogus.Faker("uk");
        List<User> users = new List<User>
        {
            new Member(1, "Tim", "Thijsen", "same@mail.com", 22, MemberType.free_account, true, "password")
        };

        int _id = 2;
		public User GetUser(int id)
		{
			int index = users.FindIndex(u => u.Id == id);
            
			return users[index];
		}

		public string[] GetCredentials(string email)
		{
			throw new NotImplementedException();
		}

        public void AddUser(User user)
        {
            if (users.Find(u => u.Email == user.Email) != null)
            {
                throw new ValidationException();
            }
            User userToAdd = new Member(_id,user.FirstName,user.LastName,user.Email,user.Age,((Member)user).MemberType,false,user.Password);
            _id++;

            users.Add(userToAdd);
        }

        public void RemoveUser(int id)
        {
            users.RemoveAt(users.FindIndex(u => u.Id == id));
        }

        public void ChangePassword(string newPwd, int userId)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            int index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
            }
            
        }
        public List<User> GetAllUser()
        {
            return users;
        }

        public User? GetUserByEmail(string email)
        {
            int index = users.FindIndex(u => u.Email == email);
            if(index < 0)
            {
                return null;
            }
            return users[index];
        }
    }
}
