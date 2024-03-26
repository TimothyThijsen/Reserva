using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IMemberDAL
    {
        void AddMember(Member member);
        void RemoveMember(int id);
        string[] GetCredentials(string email);
        void ChangePassword(string oldPwd, string newPwd, int userId);
        void EditMember(Member member);
        Member GetMember(int id);
        List<Member> GetAllMembers();
    }
}
