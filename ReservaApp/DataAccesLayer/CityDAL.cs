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
    public class CityDAL : ICityDAL
    {
        DatabaseConnection dbConnection;
        public CityDAL() 
        {
            dbConnection = new DatabaseConnection();
        }

        public void AddCity(City city)
        {
            string query = "INSERT INTO [City] (name) VALUES (@name)";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", city.Name);

            dbConnection.ModifyDB(cmd);
        }

        public List<City> GetAllCities()
        {
            string query = "SELECT * FROM [city];";
            using SqlCommand cmd = new SqlCommand(query);
            List<City> cities = new List<City>();
            try
            {
                using SqlDataReader reader = dbConnection.GetFromDB(cmd);
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    cities.Add(new City(id, name));
                }
            }catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally{
                if(cmd is IDisposable disposable)
                {
                    cmd.Dispose();
                }
                
            }
            return cities
        }

        public City GetCity(int cityId)
        {
            string query = "SELECT * FROM [city] WHERE id = @id;";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", cityId);
            City city;
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reader.Read();
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                city = new City(id, name);
                
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd is IDisposable disposable)
                {
                    cmd.Dispose();
                }

            }
            return city;
        }

        public void RemoveCity(int id)
        {
            string query = "DELETE FROM [City] WHERE id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            dbConnection.ModifyDB(cmd);
        }

        public void UpdateCity(City city)
        {
            string query = "UPDATE [City] SET name = @name WHERE id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", city.Name);
            cmd.Parameters.AddWithValue("@id", city.Id);
            dbConnection.ModifyDB(cmd);
        }
    }
}
