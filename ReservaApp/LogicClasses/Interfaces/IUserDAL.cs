namespace DomainLayer.Interfaces
{
    public interface IUserDAL
    {
        void AddUser(User user);
        void RemoveUser(int id);
        User GetUserByEmail(string email);
        void ChangePassword(string newPwd, int userId);
        void EditUser(User user);
        User GetUser(int id);
        List<User> GetAllUser();
    }
}
