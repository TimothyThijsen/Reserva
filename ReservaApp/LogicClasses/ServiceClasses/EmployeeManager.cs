using DomainLayer;
using DomainLayer.Exceptions;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Enums;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainLayer.ServiceClasses
{
	public class EmployeeManager
	{
		IUserDAL userDAL;
		public EmployeeManager(IUserDAL userDAL)
		{
			this.userDAL = userDAL;
		}

		public void AddEmployee(MemberModel memberModel)
		{
			if (!ObjectValidator.HasNoEmptyFields(memberModel))
			{
				throw new ValidationException("Incomplete member model");
			}

			//Member member = memberModel.ToLogicLayer();
			//member.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(member.Password);

			//.AddUser(member);
		}

		public void RemoveEmployee(int id)
		{
			userDAL.RemoveUser(id);
		}
		public Member GetEmployee(int id)
		{
			return (Member)userDAL.GetUser(id);
		}

		public List<Member> GetAllMembers()
		{
			return userDAL.GetAllUser().Select(x => (Member)x).ToList();
		}
		public Member GetEmployeeByEmail(string email)
		{
			return (Member)userDAL.GetUserByEmail(email);
		}
		public Member Login(string email, string password)
		{
			Member member = GetEmployeeByEmail(email);
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
