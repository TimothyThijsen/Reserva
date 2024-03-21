using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class HotelDAL : IHotelDAL
    {
        IConnection dbConnection; 

        public HotelDAL()
        {
            dbConnection = new DatabaseConnection();
        }
        public void AddHotel(Hotel hotel)
        {
            string query = "CreateHotel @name, @description, @cityId, @street, @postalCode;";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", hotel.Name);
            cmd.Parameters.AddWithValue("@description", hotel.Description);
            cmd.Parameters.AddWithValue("@cityId", hotel.CityId);
            cmd.Parameters.AddWithValue("@street", hotel.Address.Street);
            cmd.Parameters.AddWithValue("@postalCode", hotel.Address.PostalCode);

            dbConnection.ModifyDB(cmd);
        }

        public void EditHotel(Hotel hotel)
        {
           
            try
            {
                string query = "UPDATE [Hotel] SET name = @name, description = @description, cityId = @cityId WHERE id = @id;  UPDATE [Address] SET street = @street, postalCode = @postalCode WHERE id = (SELECT addressId FROM [Hotel] WHERE id = @id);";
                using SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", hotel.Id);
                cmd.Parameters.AddWithValue("@name", hotel.Name);
                cmd.Parameters.AddWithValue("@description", hotel.Description);
                cmd.Parameters.AddWithValue("@cityId", hotel.CityId);
                cmd.Parameters.AddWithValue("@street", hotel.Address.Street);
                cmd.Parameters.AddWithValue("@postalCode", hotel.Address.PostalCode);

                dbConnection.ModifyDB(cmd);
            }catch (SqlException ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Hotel> GetAllHotels()
        {
            string query = "SELECT * FROM [vwHotel]";
            using SqlCommand cmd = new SqlCommand(query);
            List<Hotel> hotels = new List<Hotel>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                
                hotels = HotelMapper.GetHotels(reader);
                
            }
            catch(SqlException ex)
            {
                //if(ex.Number = )
                throw new Exception("Unable to reach database!");
            }
            finally
            {
                if (cmd is IDisposable disposable) { disposable.Dispose(); }
            }
            
            return hotels;
        }

        public Hotel GetHotelById(int id)
        {
            string query = "SELECT * FROM [vwHotel]";
            using SqlCommand cmd = new SqlCommand(query);
            Hotel hotel = null;
            try
            {
                using SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reader.Read();
                hotel = HotelMapper.GetHotel(reader);
                
            }
            catch(SqlException ex)
            {

            }

            return hotel;
        }

        public void RemoveHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
