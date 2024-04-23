using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapper
{
    public class ReservationMapper
    {
        public static Reservation GetRoomReservation(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            int userId = (int)reader["userId"];
            decimal totalPrice = (decimal)reader["totalPrice"]; 
            bool isCancelled = (bool)reader["isCancelled"]; 
            int amountOfGuests = (int)reader["amountOfGuests"];
            DateTime startDate = (DateTime)reader["startDate"]; 
            DateTime endDate = (DateTime)reader["endDate"]; 
            return new RoomReservation(id, userId, amountOfGuests, totalPrice, isCancelled, startDate, endDate);
        }

        public static List<Reservation> GetAllRoomReservations(SqlDataReader reader)
        {
            List<Reservation> roomReservations = new List<Reservation>();
            while (reader.Read())
            {
                roomReservations.Add(GetRoomReservation(reader));
            }
            return roomReservations;
        }

        public static List<IReservedRoom> GetReservedRoom(SqlDataReader reader)
        {
            List<IReservedRoom> reservedRooms = new List<IReservedRoom>();
            while (reader.Read())
            {
                int quantity = reader.GetInt32(0);
                int roomId = reader.GetInt32(1);
                ReservedRoom reservedRoom = new ReservedRoom(quantity, roomId);
                reservedRooms.Add(reservedRoom);
            }
            return reservedRooms;
        }
        public static List<Reservation> GetAllActivityReservations(SqlDataReader reader)
        {
            List<Reservation> roomReservations = new List<Reservation>();
            while (reader.Read())
            {
                roomReservations.Add(GetActivityReservation(reader));
            }
            return roomReservations;
        }
        public static Reservation GetActivityReservation(SqlDataReader reader)
        {
			int id = (int)reader["id"];
			int userId = (int)reader["userId"];
			decimal totalPrice = (decimal)reader["totalPrice"];
			bool isCancelled = (bool)reader["isCancelled"];
			int amountOfGuests = (int)reader["amountOfGuests"];
            int activitiesId = (int)reader["activitiesId"];
			DateTime date = (DateTime)reader["date"];
			return new ActivityReservation(id, userId, amountOfGuests, totalPrice, isCancelled);

        }
    }
}
