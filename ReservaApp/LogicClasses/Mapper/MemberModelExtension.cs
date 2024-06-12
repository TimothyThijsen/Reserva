using DomainLayer;
using DomainLayer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Mapper
{
	public static class MemberModelExtension
	{
		public static Member ToLogicLayer(this MemberModel memberModel)
		{
			Member member = new Member(memberModel.FirstName, memberModel.LastName, memberModel.Email.ToLower().Trim(), DateOnly.FromDateTime(memberModel.DateOfBirth), memberModel.Role, memberModel.Password);
			return member;
		}
	}
}
