using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;

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
			string query = "CreateRoom @name, @hotelId, @price, @quantity, @capacity, @bedType;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", room.Name);
			cmd.Parameters.AddWithValue("@hotelId", room.HotelId);
			cmd.Parameters.AddWithValue("@price", room.Price);
			cmd.Parameters.AddWithValue("@quantity", room.Quantity);
			cmd.Parameters.AddWithValue("@capacity", room.Capacity);
			cmd.Parameters.AddWithValue("@bedType", room.BedType);

			try
			{

				dbConnection.ModifyDB(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void EditRoom(Room room)
		{
			string query = "CreateRoom @name, @hotelId, @price, @quantity, @capacity, @bedType;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", room.Name);
			cmd.Parameters.AddWithValue("@hotelId", room.HotelId);
			cmd.Parameters.AddWithValue("@price", room.Price);
			cmd.Parameters.AddWithValue("@quantity", room.Quantity);
			cmd.Parameters.AddWithValue("@capacity", room.Capacity);
			cmd.Parameters.AddWithValue("@bedType", room.BedType);
			try
			{


				dbConnection.ModifyDB(cmd);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<Room> GetAllRooms()
		{
			string query = "SELECT * FROM [vwRoom]";
			SqlCommand cmd = new SqlCommand(query);
			SqlDataReader reader = dbConnection.GetFromDB(cmd);
			List<Room> rooms = new List<Room>();
			while (reader.Read())
			{
				int id = reader.GetInt32(0);
				int hotelId = reader.GetInt32(1);
				string name = reader.GetString(2);
				int quantity = reader.GetInt32(3);
				decimal price = reader.GetDecimal(4);
				int capacity = reader.GetInt32(5);
				string bedType = reader.GetString(6);

				rooms.Add(new Room(id, hotelId, name, quantity, price, capacity, bedType));

			}
			return rooms;
		}

		public List<Room> GetAllRoomsByHotel(int hotelId)
		{
			string query = "SELECT * FROM [vwRoom] WHERE hotelId = @hotelId";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@hotelId", hotelId);
			List<Room> rooms = new List<Room>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);

				while (reader.Read())
				{
					int id = reader.GetInt32(0);
					string name = reader.GetString(2);
					int quantity = reader.GetInt32(3);
					decimal price = reader.GetDecimal(4);
					int capacity = reader.GetInt32(5);
					string bedType = reader.GetString(6);
					rooms.Add(new Room(id, hotelId, name, quantity, price, capacity, bedType));

				}
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd is IDisposable diposable) { diposable.Dispose(); }
			}

			return rooms;
		}

		public List<Room> GetAllRoomsByLocation(string locationName)
		{
			string query = "SELECT * FROM [vwRoom] WHERE cityName = @locationName";
			SqlCommand cmd = new SqlCommand(query);
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
				int capacity = reader.GetInt32(5);
				string bedType = reader.GetString(6);
				rooms.Add(new Room(id, hotelId, name, quantity, price, capacity, bedType));

			}
			return rooms;
		}

		public Room GetRoomById(int id)
		{
			string query = "SELECT * FROM [vwRoom] where id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
			SqlDataReader reader = dbConnection.GetFromDB(cmd);
			Room room;
			reader.Read();
			if (reader.IsDBNull(0))
			{
				return null;
			}
			int hotelId = reader.GetInt32(1);
			string name = reader.GetString(2);
			int quantity = reader.GetInt32(3);
			decimal price = reader.GetDecimal(4);
			int capacity = reader.GetInt32(5);
			string bedType = reader.GetString(6);

			room = new Room(id, hotelId, name, quantity, price, capacity, bedType);

			return room;
		}

		public void RemoveRoom(int id)
		{
			throw new NotImplementedException();
		}
	}
}
