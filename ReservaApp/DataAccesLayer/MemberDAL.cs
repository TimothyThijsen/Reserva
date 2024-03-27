using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MemberDAL : IUserDAL
    {
        IConnection dbConnection;

        public MemberDAL()
        {
            dbConnection = new DatabaseConnection();
        }
        public void AddUser(User user)
        {
            Member member = (Member)user;
            string query = "CreateMember @name, @email, @password, @age, @role, @verified;";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", member.FirstName + " " + member.LastName);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@password", member.Password);
            cmd.Parameters.AddWithValue("@age", member.Age);
            cmd.Parameters.AddWithValue("@role", member.MemberType);
            cmd.Parameters.AddWithValue("@verified", member.Verified);

            dbConnection.ModifyDB(cmd);
        }

        public void ChangePassword(string newPwd, int userId)
        {
            string query = "UPDATE [User] SET password = @password WHERE id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@password", newPwd);
            cmd.Parameters.AddWithValue("@id", userId);
            dbConnection.ModifyDB(cmd);
        }

        public void EditUser(User user)
        {
            Member member = (Member)user;
            string query = "UpdateMember @id, @name, @email, @age, @role, @points, @verified;";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", member.Id);
            cmd.Parameters.AddWithValue("@name", member.FirstName + " " + member.LastName);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@age", member.Age);
            cmd.Parameters.AddWithValue("@role", member.MemberType);
            cmd.Parameters.AddWithValue("@points", member.Points);
            cmd.Parameters.AddWithValue("@verified", member.Verified);

            dbConnection.ModifyDB(cmd);
        }

        public List<User> GetAllUser()
        {
            string query = "SELECT * FROM [vwMember]";
            using SqlCommand cmd = new SqlCommand(query);
            List<User> members = new List<User>();
            try
            {
                using SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reader.Read();
                members = MemberMapper.GetMembers(reader);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }

        public string[] GetCredentials(string email)
        {
            string query = "SELECT id,email,password FROM [User] WHERE email = @email";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);
            string[] credentials;
            try
            {
                using SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reader.Read();
                credentials = new string[]
                {
                    reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2)
                };
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return credentials;
        }

        public User GetUser(int id)
        {
            string query = "SELECT * FROM [vwMember] where id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            Member member = null;
            try
            {
                using SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reader.Read();
                member = MemberMapper.GetMember(reader);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public void RemoveUser(int id)
        {
            string query = "DELETE FROM [Member] where id = @id; DELETE FROM [User] where id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            dbConnection.ModifyDB(cmd);
        }
    }
}
