using DomainLayer.Interfaces;
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
        IMemberDAL memberDAL;
        public MemberManager(IMemberDAL memberDAL) 
        { 
            this.memberDAL = memberDAL;
        }

        public void AddMember(Member member)
        {
            List<Member> members = GetAllMembers();
            
            if (members.Find(u => u.Email == member.Email) != null)
            {
                throw new ValidationException($"Email is already in use!");
            }
            member.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(member.Password);

            memberDAL.AddMember(member);
        }

        public void RemoveMember(int id)
        {
            memberDAL.RemoveMember(id);
        }
        public Member GetMember(int id)
        {
            return memberDAL.GetMember(id);
        }

        public List<Member> GetAllMembers()
        {
            return memberDAL.GetAllMembers();
        }
        public Member Login(string email, string password)
        {
            string[] credentials = memberDAL.GetCredentials(email.ToLower());
            if (credentials[0] == null)
            {
                throw new Exception("No member found with that email");
            }
            Member member;
            if (BCrypt.Net.BCrypt.EnhancedVerify(password, credentials[1]))
            {
                member = GetMember(Convert.ToInt32(credentials[0]));
            }
            else
            {
                throw new Exception("Incorrect password");
            }
            return member;

        }
    }
}
