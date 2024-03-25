using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IUserDAL
    {
        void AddUser(User user);
        void RemoveUser(int id);
        string[] GetCredentials(string email);
        void ChangePassword(string oldPwd, string newPwd, int userId);
        void EditUser(Member member);
        User GetUser(int id);
        List<Member> GetAllMembers();
        List<Employee> GetAllEmployees();
    }
}
