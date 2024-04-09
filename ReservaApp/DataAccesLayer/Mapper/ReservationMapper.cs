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
        public static Reservation GetReservation(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            int userId = reader.GetInt32(1);
            decimal totalPaid = reader.GetDecimal(2);
            decimal totalPrice = reader.GetDecimal(3);
            bool isCancelled = reader.GetBoolean(4);
            int amountOfGuests = reader.GetInt32(5);
            if (!reader.IsDBNull(6))
            {
                DateTime startDate = reader.GetDateTime(6);
                DateTime endDate = reader.GetDateTime(7);
                return new RoomReservation(id, userId, amountOfGuests, totalPaid, totalPrice, isCancelled, startDate, endDate);
            }
            
            int activitiesId = reader.GetInt32(8);
            DateTime date = reader.GetDateTime(9);
            return new ActivityReservation(id, userId, amountOfGuests, totalPaid, totalPrice, isCancelled);

    }

        public static List<Reservation> GetAllReservations(SqlDataReader reader)
        {
            List<Reservation> roomReservations = new List<Reservation>();
            while (reader.Read())
            {
                roomReservations.Add(GetReservation(reader));
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
                ReservedRoom reservedRoom = new ReservedRoom();
                reservedRoom.RoomId = roomId;
                reservedRoom.Quantity = quantity;
                reservedRooms.Add(reservedRoom);
            }
            return reservedRooms;
        }
    }
}
