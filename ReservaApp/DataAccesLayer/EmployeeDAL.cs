using DomainLayer;
using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class EmployeeDAL : IUserDAL
	{
		public void AddUser(User user)
		{
			throw new NotImplementedException();
		}

		public void ChangePassword(string newPwd, int userId)
		{
			throw new NotImplementedException();
		}

		public void EditUser(User user)
		{
			throw new NotImplementedException();
		}

		public List<User> GetAllUser()
		{
			throw new NotImplementedException();
		}

		public User GetUser(int id)
		{
			throw new NotImplementedException();
		}

		public User GetUserByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public void RemoveUser(int id)
		{
			throw new NotImplementedException();
		}
	}
}
