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
			string query = "EXEC CreateHotel @name, @description, @cityId, @street, @postalCode;";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", hotel.Name);
			cmd.Parameters.AddWithValue("@description", hotel.Description);
			cmd.Parameters.AddWithValue("@cityId", hotel.CityId);
			cmd.Parameters.AddWithValue("@street", hotel.Address.Street);
			cmd.Parameters.AddWithValue("@postalCode", hotel.Address.PostalCode);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void EditHotel(Hotel hotel)
		{
			string query = "UPDATE [Hotel] SET name = @name, description = @description, " +
					 "cityId = @cityId WHERE id = @id;  UPDATE [Address] SET street = @street, " +
					 "postalCode = @postalCode WHERE id = (SELECT addressId FROM [Hotel] WHERE id = @id);";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", hotel.Id);
			cmd.Parameters.AddWithValue("@name", hotel.Name);
			cmd.Parameters.AddWithValue("@description", hotel.Description);
			cmd.Parameters.AddWithValue("@cityId", hotel.CityId);
			cmd.Parameters.AddWithValue("@street", hotel.Address.Street);
			cmd.Parameters.AddWithValue("@postalCode", hotel.Address.PostalCode);
			try
			{
				dbConnection.ModifyDB(cmd);
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public List<Hotel> GetAllHotels()
		{
			string query = "SELECT * FROM [vwHotel]";
			SqlCommand cmd = new SqlCommand(query);
			List<Hotel> hotels = new List<Hotel>();
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				
				hotels = HotelMapper.GetHotels(reader);
				cmd.Connection.Close();
				foreach(Hotel h in hotels)
				{
					cmd.CommandText = "SELECT * FROM [vwRoom] WHERE hotelId = @hotelId";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@hotelId", h.Id);
					reader = dbConnection.GetFromDB(cmd);
					h.Rooms = RoomMapper.GetAllRooms(reader);
				}

			}
			catch (SqlException)
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

        public Hotel GetHotelAndRoomsById(int id)
        {
            string query = "SELECT * FROM [vwHotel] where id = @id; SELECT * FROM [vwRoom] where hotelId = @id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            Hotel hotel = null;
            try
            {
				

				
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                int index = 0;

                reader.Read();
				
                hotel = HotelMapper.GetHotel(reader);
				reader.NextResult();

                hotel.Rooms = RoomMapper.GetAllRooms(reader);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd is IDisposable disposable) { disposable.Dispose(); }
            }

            return hotel;
        }

        public Hotel GetHotelById(int id)
		{
			string query = "SELECT * FROM [vwHotel] where id = @id";
			SqlCommand cmd = new SqlCommand(query);
			cmd.Parameters.AddWithValue("@id", id);
			Hotel hotel = null;
			try
			{
				SqlDataReader reader = dbConnection.GetFromDB(cmd);
				reader.Read();
				hotel = HotelMapper.GetHotel(reader);

			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd is IDisposable disposable) { disposable.Dispose(); }
			}

			return hotel;
		}

		public void RemoveHotel(int id)
		{
			throw new NotImplementedException();
		}
	}
}
