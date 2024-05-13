using DomainLayer.Exceptions;
using DomainLayer.Interfaces;
using DomainLayer.Mapper;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ServiceClasses
{
    public class MemberManager
    {
        IUserDAL userDAL;
        public MemberManager(IUserDAL userDAL) 
        { 
            this.userDAL = userDAL;
        }
        
        public void AddMember(MemberModel memberModel)
        {
            List<Member> members = GetAllMembers();

            if(!ObjectValidator.HasNoEmptyFields(memberModel)) 
            {
                throw new ValidationException("Incomplete member model");
            }
            //Fixe
            if (members.Find(u => u.Email == memberModel.Email) != null)
            {
                throw new ValidationException($"Email is already in use!");
            }
            Member member = memberModel.ToLogicLayer();
            member.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(member.Password);

            userDAL.AddUser(member);
        }

        public void RemoveMember(int id)
        {
            userDAL.RemoveUser(id);
        }
        public Member GetMember(int id)
        {
            return (Member)userDAL.GetUser(id);
        }

        public List<Member> GetAllMembers()
        {
            return userDAL.GetAllUser().Select(x => (Member)x).ToList();
        }
        public Member GetMemberByEmail(string email)
        {
            return (Member)userDAL.GetUserByEmail(email);
        }
        public Member Login(string email, string password)
        {
            Member member = GetMemberByEmail(email);
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
