using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;

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
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", member.FirstName + " " + member.LastName);
			cmd.Parameters.AddWithValue("@email", member.Email);
			cmd.Parameters.AddWithValue("@password", member.Password);
			cmd.Parameters.AddWithValue("@age", member.Age);
			cmd.Parameters.AddWithValue("@role", member.MemberType);
			cmd.Parameters.AddWithValue("@verified", member.Verified);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }

		}

		public void ChangePassword(string newPwd, int userId)
		{
			string query = "UPDATE [User] SET password = @password WHERE id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@password", newPwd);
			cmd.Parameters.AddWithValue("@id", userId);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}

		public void EditUser(User user)
		{
			Member member = (Member)user;
			string query = "UpdateMember @id, @name, @email, @age, @role, @points, @verified;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", member.Id);
			cmd.Parameters.AddWithValue("@name", member.FirstName + " " + member.LastName);
			cmd.Parameters.AddWithValue("@email", member.Email);
			cmd.Parameters.AddWithValue("@age", member.Age);
			cmd.Parameters.AddWithValue("@role", member.MemberType);
			cmd.Parameters.AddWithValue("@points", member.Points);
			cmd.Parameters.AddWithValue("@verified", member.Verified);

			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}

		public List<User> GetAllUser()
		{
			string query = "SELECT * FROM [vwMember]";
			SqlCommand cmd = new SqlCommand(query);
			List<User> members = new List<User>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
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
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.AddWithValue("@email", email);
			string[] credentials;
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
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
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.AddWithValue("@id", id);
			Member member = null;
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
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
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}
	}
}
