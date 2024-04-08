using DomainLayer;
using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Mapper
{
	public static class MemberModelExtension
	{

		public static Member ToLogicLayer(this IMemberModel memberModel)
		{
			Member member = new Member(memberModel.FirstName, memberModel.LastName, memberModel.Email, memberModel.Age, memberModel.Role);
			member.Password = memberModel.Password;
			return member;
		}
		

	}
}
