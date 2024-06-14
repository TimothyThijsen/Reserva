using DomainLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Mapper
{
    public class RoomMapper
    {
        public static Room GetRoom(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            int hotelId = (int)reader["hotelId"];
            string name = (string)reader["name"];
            int quantity = (int)reader["quantity"];
            decimal price = (decimal)reader["price"];
            int capacity = (int)reader["capacity"];
            string bedType = (string)reader["bedType"];
            return new Room(id, hotelId, name, quantity, price, capacity, bedType);
        }

        public static List<Room> GetAllRooms(SqlDataReader reader)
        {
            List<Room> list = new List<Room>();
            while (reader.Read())
            {
                list.Add(GetRoom(reader));
            }
            return list;
        }

    }
}
