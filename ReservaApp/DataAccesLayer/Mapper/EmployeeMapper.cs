using DomainLayer;
using Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapper
{
	public class EmployeeMapper
	{
		public static Employee GetEmployee(SqlDataReader reader)
		{
			int id = Convert.ToInt32(reader["id"]);
			string[] name = Convert.ToString(reader["name"])!.Split(' ');
			string firstName = name[0];
			string lastName = name[1];
			string email = Convert.ToString(reader["email"])!;
			DateOnly dateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(reader["dateOfBirth"]));
			EmployeeRole role = (EmployeeRole)Convert.ToInt32(reader["role"]);
			decimal salary = Convert.ToDecimal(reader["salary"])!;
			string phoneNumber = Convert.ToString(reader["phoneNumber"])!;
			string password = Convert.ToString(reader["password"]);
			return new Employee(id, firstName, lastName, email, dateOfBirth, password, salary, phoneNumber, role);
		}

		public static List<User> GetEmployees(SqlDataReader reader)
		{
			List<User> employees = new List<User>();
			while (reader.Read())
			{
				employees.Add(GetEmployee(reader));
			}
			return employees;
		}
	}
}
