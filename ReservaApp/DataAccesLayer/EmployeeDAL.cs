using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Exceptions;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class EmployeeDAL : IUserDAL
	{
		IConnection dbConnection;

		public EmployeeDAL()
		{
			dbConnection = new DatabaseConnection();
		}
		public void AddUser(User user)
		{
			Employee employee = (Employee)user;
			string query = "BEGIN DECLARE @userId INT; INSERT INTO [User] (name, email, password, role, dateOfBirth) VALUES (@name, @email, @password,  @role, @dateOfBirth);SET @userId = SCOPE_IDENTITY();" +
				"INSERT INTO [Employee] (id, salary, phoneNumber) VALUES (@userId, @salary, @phoneNumber);";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", employee.FirstName + " " + employee.LastName);
			cmd.Parameters.AddWithValue("@email", employee.Email);
			cmd.Parameters.AddWithValue("@password", employee.Password);
			cmd.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
			cmd.Parameters.AddWithValue("@role", (int)employee.Role);
			cmd.Parameters.AddWithValue("@salary", employee.Salary);
			cmd.Parameters.AddWithValue("@phoneNumber", employee.PhoneNUmber);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex)
			{

				switch (ex.Number)
				{
					case 53:
						throw new RepositoryUnavailableException();
					case 2601:
						throw new EmailValidationException();
				}
				throw new Exception(ex.Message);
			}
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
			Employee employee = (Employee)user;
			string query = "UPDATE [User] SET name = @name, email = @mail, dateOfBirth = @dateOfBirth, role = @role WHERE id = @userId;" +
				"UPDATE [employee] SET salary = @salary, phoneNumber = @phoneNumber WHERE id = @userId";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", employee.FirstName + " " + employee.LastName);
			cmd.Parameters.AddWithValue("@userId", employee.Id);
			cmd.Parameters.AddWithValue("@email", employee.Email);
			cmd.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
			cmd.Parameters.AddWithValue("@role", (int)employee.Role);
			cmd.Parameters.AddWithValue("@salary", employee.Salary);
			cmd.Parameters.AddWithValue("@phoneNumber", employee.PhoneNUmber);

			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}

		public List<User> GetAllUser()
		{
			string query = "SELECT * FROM [vwEmployee]";
			SqlCommand cmd = new SqlCommand(query);
			List<User> employees = new List<User>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				reader.Read();
				employees = EmployeeMapper.GetEmployees(reader);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd is IDisposable diposable)
				{
					cmd.Connection.Close();
					diposable.Dispose();
				}
			}

			return employees;
		}

		public User GetUser(int id)
		{
			string query = "SELECT * FROM [vwEmployee] where id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.AddWithValue("@id", id);
			Employee employee = null!;
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				reader.Read();
				employee = EmployeeMapper.GetEmployee(reader);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd is IDisposable diposable)
				{
					cmd.Connection.Close();
					diposable.Dispose();
				}
			}
			return employee;
		}

		public User GetUserByEmail(string email)
		{
			string query = "SELECT * FROM [vwEmployee] where email = @email";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.AddWithValue("@email", email);
			Employee employee = null!;
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				reader.Read();
				employee = EmployeeMapper.GetEmployee(reader);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd is IDisposable diposable)
				{
					cmd.Connection.Close();
					diposable.Dispose();
				}
			}

			return employee;
		}

		public void RemoveUser(int id)
		{
			string query = "DELETE FROM [Employee] where id = @id; DELETE FROM [User] where id = @id";
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
