using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DomainLayer.Interface;
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
            using SqlCommand cmd = new SqlCommand();
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
            SqlDataReader reader = dbConnection.GetFromDB(cmd);
            List<Hotel> hotels = new List<Hotel>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int cityId = reader.GetInt32(2);
                int addressId = reader.GetInt32(3);
                string street = reader.GetString(4);
                string postalCode = reader.GetString(5);
                string description = reader.GetString(6);

                hotels.Add(new Hotel(id, name, description, cityId, new Address(street, postalCode)));

            }
            cmd.Connection.Close();
            foreach (Hotel hotel in hotels)
            {
                query = "SELECT * FROM [Room] WHERE hotelId = @hotelId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@hotelId", hotel.Id);
                cmd.CommandText = query;
                reader = dbConnection.GetFromDB(cmd);
                List<int> rooms = new List<int>();
                while (reader.Read())
                {
                    rooms.Add(reader.GetInt32(0));
                }
                hotel.Rooms = rooms;
                cmd.Connection.Close();
            }
            return hotels;
        }

        public Hotel GetHotelById(int id)
        {
            string query = "SELECT * FROM [vwHotel]";
            using SqlCommand cmd = new SqlCommand(query);
            SqlDataReader reader = dbConnection.GetFromDB(cmd);
            Hotel hotel = null;
            reader.Read();
            string name = reader.GetString(1);
            int cityId = reader.GetInt32(2);
            int addressId = reader.GetInt32(3);
            string street = reader.GetString(4);
            string postalCode = reader.GetString(5);
            string description = reader.GetString(6);

            hotel = (id, name, description, cityId, new Address(street, postalCode)));
            cmd.Connection.Close();

            query = "SELECT * FROM [Room] WHERE hotelId = @hotelId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@hotelId", hotel.Id);
            cmd.CommandText = query;
            reader = dbConnection.GetFromDB(cmd);
            List<int> rooms = new List<int>();
            while (reader.Read())
            {
                rooms.Add(reader.GetInt32(0));
            }
            hotel.Rooms = rooms;
            cmd.Connection.Close();
            
            return hotel;
        }

        public void RemoveHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
