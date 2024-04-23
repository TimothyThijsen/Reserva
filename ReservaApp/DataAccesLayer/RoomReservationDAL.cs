using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomReservationDAL : IReservationDAL
    {
        IConnection dbConnection;
        public RoomReservationDAL()
        {
            dbConnection = new DatabaseConnection();
        }
        public void CreateReservation(Reservation reservation)
        {
            RoomReservation roomReservation = (RoomReservation)reservation;
            string query = "BEGIN DECLARE @reservationId INT; EXEC CreateRoomReservation @userId, @totalPrice, @isCancelled, @amountOfGuests, @startDate, @endDate, @reservationId OUTPUT;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@userId", roomReservation.UserId);
            cmd.Parameters.AddWithValue("@totalPrice", roomReservation.TotalPrice);
            cmd.Parameters.AddWithValue("@isCancelled", roomReservation.IsCanceled);
            cmd.Parameters.AddWithValue("@amountOfGuests", roomReservation.AmountOfGuest);
            cmd.Parameters.AddWithValue("@startDate", roomReservation.DateRange.Start);
            cmd.Parameters.AddWithValue("@endDate", roomReservation.DateRange.End);
            List<IReservedRoom> roomIds = roomReservation.ReservedRooms;
            int countCheck = 0;
            foreach (IReservedRoom rm in roomIds)
            {
                int index = 0;
                while (index < rm.Quantity)
                {
                    cmd.CommandText += $" INSERT INTO [ReservedRoom] (roomId,reservationId) VALUES (@roomId{index}, @reservationId);";
                    cmd.Parameters.AddWithValue($"@roomId{index}", rm.RoomId);
                    index++;
                }
                countCheck += index;
            }
            cmd.CommandText += " END";
            if (countCheck != roomIds.Sum(rm => rm.Quantity))
            {
                throw new Exception("A problem has occurred trying to make reservation.");
            }

            try
            {
                dbConnection.ModifyDB(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            string query = "UPDATE [Reservation] SET totalPrice = @totalPrice, isCancelled = @isCancelled WHERE reservationId = @reservationId";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reservationId", reservation.Id);
            cmd.Parameters.AddWithValue("@totalPrice", reservation.TotalPrice);
            cmd.Parameters.AddWithValue("@isCancelled", reservation.IsCanceled);
            try
            {
                dbConnection.ModifyDB(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Reservation> GetAllReservationByMember(int userId)
        {
            string query = "SELECT r.id, r.userId, r.totalPrice , r.isCanceled, r.amountOfGuests, rm.startDate, rm.endDate FROM Reservation r " +
                "LEFT JOIN RoomReservation rm ON r.id = rm.id  WHERE r.userId = @userId and rm.id IS NOT NULL";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@userId", userId);
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservations = ReservationMapper.GetAllRoomReservations(reader);
                foreach (RoomReservation roomReservation in reservations)
                {
                    cmd.Connection.Close();
                    query = "SELECT COUNT(roomId), roomId FROM ReservedRoom WHERE reservationId = @reservationId  GROUP BY roomId";
                    cmd = new SqlCommand(query);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@reservationId", roomReservation.Id);
                    reader = dbConnection.GetFromDB(cmd);
                    roomReservation.ReservedRooms = ReservationMapper.GetReservedRoom(reader);
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
            return reservations;
        }

        public List<Reservation> GetAllReservationByEntityId(int entityId)
        {
            string query = "SELECT DISTINCT * FROM [vwRoomReservation] WHERE roomId = @roomId AND endDate > @today";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@roomId", entityId);
            cmd.Parameters.AddWithValue("@today", DateTime.Today);

            List<Reservation> roomReservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                roomReservations = ReservationMapper.GetAllRoomReservations(reader);
                foreach (RoomReservation roomReservation in roomReservations)
                {
                    cmd.Connection.Close();
                    query = "SELECT COUNT(roomId), roomId FROM ReservedRoom WHERE reservationId = @reservationId  GROUP BY roomId";
                    cmd = new SqlCommand(query);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@reservationId", roomReservation.Id);
                    reader = dbConnection.GetFromDB(cmd);
                    roomReservation.ReservedRooms = ReservationMapper.GetReservedRoom(reader);
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
            return roomReservations.Cast<Reservation>().ToList();
        }

        public Reservation GetByReservationId(int id)
        {
            string query = "SELECT r.id, r.userId, r.totalPrice , r.isCanceled, r.amountOfGuests, rm.startDate, rm.endDate FROM Reservation r " +
               "left JOIN RoomReservation rm ON r.id = rm.id WHERE r.id = @reservationId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@reservationId", id);
            Reservation reservation;
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservation = ReservationMapper.GetRoomReservation(reader);

                cmd.Connection.Close();
                query = "SELECT COUNT(roomId), roomId FROM ReservedRoom WHERE reservationId = @reservationId  GROUP BY roomId";
                cmd = new SqlCommand(query);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@reservationId", reservation.Id);
                reader = dbConnection.GetFromDB(cmd);
                ((RoomReservation)reservation).ReservedRooms = ReservationMapper.GetReservedRoom(reader);
                
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd is IDisposable diposable) { diposable.Dispose(); }
            }
            return reservation;
        }
    }
}
