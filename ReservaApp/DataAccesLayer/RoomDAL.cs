using DomainLayer;
using DomainLayer.Interfaces;
using DataAccessLayer.Mapper;
using DomainLayer.ServiceClasses;
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
			string query = "EXEC CreateRoom @name, @hotelId, @price, @quantity, @capacity, @bedType;";
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
			string query = "UPDATE Room SET hotelId = @hotelId, name = @name, quantity = @quantity, price = @price, " +
				"capacity = @capacity, bedType = @bedType WHERE id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", room.Id);
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
			List<Room> rooms = new List<Room>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				rooms = RoomMapper.GetAllRooms(reader);
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
				rooms = RoomMapper.GetAllRooms(reader);

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
            return rooms;
		}

		public List<Room> GetAllRoomsByLocation(string locationName)
		{
			string query = "SELECT * FROM [vwRoom] WHERE cityName = @locationName";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@locationName", locationName);
			List<Room> rooms = new List<Room>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				rooms = RoomMapper.GetAllRooms(reader);
				cmd.Connection.Close();
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
            return rooms;
		}

		public Room? GetRoomById(int id)
		{
			string query = "SELECT * FROM [vwRoom] where id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
			SqlDataReader reader = dbConnection.GetFromDB(cmd);
			Room room;
			try
			{
				reader.Read();
				if (reader.IsDBNull(0))
				{
					return null;
				}
				room = RoomMapper.GetRoom(reader);
				
			}catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}finally { if (cmd is IDisposable diposable) { 
					cmd.Connection.Close(); 
					diposable.Dispose(); }}
            return room;
        }

		public void RemoveRoom(int id)
		{
			string query = "DELETE FROM [ReservedRoom] WHERE roomId = @id; DELETE FROM [Room] WHERE id = @id;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);

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
