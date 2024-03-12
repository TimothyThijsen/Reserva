using DomainLayer;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomDAL : IRoomDAL
    {
        IConnection dbConnection;
        public RoomDAL() 
        { 
            dbConnection = new DatabaseConnection();
        }
        public void AddRoom(Room room)
        {
            try
            {
                string query = "CreateRoom @name, @hotelId, @price, @quantity;";
                using SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", room.Name);
                cmd.Parameters.AddWithValue("@hotelId", room.HotelId);
                cmd.Parameters.AddWithValue("@price", room.Price);
                cmd.Parameters.AddWithValue("@quantity", room.Quantity);


                dbConnection.ModifyDB(cmd);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void EditRoom(Room room)
        {
            try
            {
                string query = "CreateRoom @name, @hotelId, @price, @quantity;";
                using SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", room.Name);
                cmd.Parameters.AddWithValue("@hotelId", room.HotelId);
                cmd.Parameters.AddWithValue("@price", room.Price);
                cmd.Parameters.AddWithValue("@quantity", room.Quantity);


                dbConnection.ModifyDB(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM [vwRooms]";
            using SqlCommand cmd = new SqlCommand(query);
            SqlDataReader reader = dbConnection.GetFromDB(cmd);
            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int hotelId = reader.GetInt32(1);
                string name = reader.GetString(2);
                int quantity = reader.GetInt32(3);
                decimal price = reader.GetDecimal(4);

                rooms.Add(new Room(id, hotelId, name, quantity, price));

            }
            return rooms;
        }

        public List<Room> GetAllRoomsByLocation(string locationName)
        {
            string query = "SELECT * FROM [vwRooms] WHERE cityName = @locationName";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@locationName", locationName);
            SqlDataReader reader = dbConnection.GetFromDB(cmd);
            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int hotelId = reader.GetInt32(1);
                string name = reader.GetString(2);
                int quantity = reader.GetInt32(3);
                decimal price = reader.GetDecimal(4);

                rooms.Add(new Room(id, hotelId, name, quantity, price));

            }
            return rooms;
        }

        public Room GetRoomById(int id)
        {
            string query = "SELECT * FROM [vwRooms] where id = @id";
            using SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = dbConnection.GetFromDB(cmd);
            Room room;
            reader.Read();
            if(reader.GetInt32(0) == null)
            {
                return null;
            }
            int hotelId = reader.GetInt32(1);
            string name = reader.GetString(2);
            int quantity = reader.GetInt32(3);
            decimal price = reader.GetDecimal(4);

            room = new Room(id, hotelId, name, quantity, price);
            
            return room;
        }

        public void RemoveRoom(int id)
        {
            throw new NotImplementedException();
        }
    }
}
