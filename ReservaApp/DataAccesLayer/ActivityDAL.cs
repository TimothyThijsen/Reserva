using DataAccessLayer.Mapper;
using DomainLayer;
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
	public class ActivityDAL : IActivityDAL
	{
		IConnection dbConnection;
		public ActivityDAL()
		{
			dbConnection = new DatabaseConnection();
		}
		public void AddActivity(Activity activity)
		{
			string query = "BEGIN DECLARE @addressId INT; INSERT INTO [Address] (street, postalCode) VALUES (@street, @postalCode); SET @addressId = SCOPE_IDENTITY();" +
				"INSERT INTO [Activity] (name, description, price, addressId, cityId, capacity) VALUES (@name, @description, @price, @addressId, @cityId, @capacity); END";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", activity.Name);
			cmd.Parameters.AddWithValue("@description", activity.Description);
			cmd.Parameters.AddWithValue("@price", activity.Price);
			cmd.Parameters.AddWithValue("@street", activity.Address.Street);
			cmd.Parameters.AddWithValue("@postalCode", activity.Address.PostalCode);
			cmd.Parameters.AddWithValue("@capacity", activity.Capacity);
			cmd.Parameters.AddWithValue("@cityId", activity.CityId);
			try
			{

				dbConnection.ModifyDB(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void EditActivity(Activity activity)
		{
			string query = "DECLARE @addressId INT; SELECT @addressId = addressId FROM [Activity] WHERE id = @id;" +
				"UPDATE [Activity] SET name = @name, description = @description, price = @price, " +
				"capacity = @capacity, cityId = @cityId WHERE id = @id;" +
				"UPDATE [Address] SET street = @street, postalCode = @postalCode WHERE id = @addressId";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", activity.Id);
			cmd.Parameters.AddWithValue("@name", activity.Name);
			cmd.Parameters.AddWithValue("@description", activity.Description);
			cmd.Parameters.AddWithValue("@price", activity.Price);
			cmd.Parameters.AddWithValue("@street", activity.Address.Street);
			cmd.Parameters.AddWithValue("@postalCode", activity.Address.PostalCode);
			cmd.Parameters.AddWithValue("@capacity", activity.Capacity);
			cmd.Parameters.AddWithValue("@cityId", activity.CityId);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Activity GetActivityById(int id)
		{
			string query = "SELECT * FROM [vwActivity] WHERE id = @id";
			SqlCommand cmd = new SqlCommand(query);
			Activity activity;
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				activity = ActivityMapper.GetActivity(reader);
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
			return activity;
		}

		public List<Activity> GetAllActivities()
		{
			string query = "SELECT * FROM [vwActivity]";
			SqlCommand cmd = new SqlCommand(query);
			List<Activity> activities = new List<Activity>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				activities = ActivityMapper.GetActivities(reader);
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
			return activities;
		}

		public List<Activity> GetAllActivitiesByCity(int cityId)
		{
			string query = "SELECT * FROM [vwActivity] WHERE cityId = @cityId";
			SqlCommand cmd = new SqlCommand(query);
			List<Activity> activities = new List<Activity>();
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@cityId", cityId);
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				activities = ActivityMapper.GetActivities(reader);
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
			return activities;
		}

		public void RemoveActivity(Activity activity)
		{
			string query = "DECLARE @addressId INT; SELECT @addressId = addressId FROM [Activity] WHERE id = @id; " +
				"DELETE FROM [Activity] WHERE id = @id; DELETE FROM [Address] WHERE id = @addressId;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", activity.Id);

			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
