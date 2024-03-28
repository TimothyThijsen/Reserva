using DomainLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Mapper
{
	public static class HotelMapper
	{
		public static Hotel GetHotel(SqlDataReader reader)
		{
			int id = reader.GetInt32(0);
			string name = reader.GetString(1);
			int cityId = reader.GetInt32(2);
			int addressId = reader.GetInt32(3);
			string street = reader.GetString(4);
			string postalCode = reader.GetString(5);
			string description = reader.GetString(6);

			return new Hotel(id, name, description, cityId, new Address(street, postalCode));
		}

		public static List<Hotel> GetHotels(SqlDataReader reader)
		{
			List<Hotel> hotels = new List<Hotel>();
			while (reader.Read())
			{
				hotels.Add(GetHotel(reader));
			}
			return hotels;
		}
	}
}
