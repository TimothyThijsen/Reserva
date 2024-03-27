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
        IUserDAL userDAL;
        public MemberManager(IUserDAL userDAL) 
        { 
            this.userDAL = userDAL;
        }

        public void AddMember(Member member)
        {
            List<Member> members = GetAllMembers();
            
            if (members.Find(u => u.Email == member.Email) != null)
            {
                throw new ValidationException($"Email is already in use!");
            }
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
        public Member Login(string email, string password)
        {
            string[] credentials = userDAL.GetCredentials(email.ToLower());
            if (credentials[0] == null)
            {
                throw new Exception("No member found with that email");//custom exception throwing credential error
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
