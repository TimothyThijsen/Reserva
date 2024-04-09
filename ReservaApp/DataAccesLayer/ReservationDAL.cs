using DataAccessLayer.Mapper;
using DomainLayer;
using DomainLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReservationDAL : IReservationDAL
    {
        IConnection dbConnection;
        public ReservationDAL()
        {
            dbConnection = new DatabaseConnection();
        }
        public void CreateReservation(Reservation reservation)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@userId", reservation.UserId);
            cmd.Parameters.AddWithValue("@amountPaid", reservation.TotalPaid);
            cmd.Parameters.AddWithValue("@totalPrice", reservation.TotalPrice);
            cmd.Parameters.AddWithValue("@isCancelled", reservation.IsCanceled);
            if(reservation.GetType() == typeof(RoomReservation) ) 
            {
                RoomReservation roomReservation = (RoomReservation)reservation;
                cmd.CommandText = "BEGIN DECLARE @reservationId INT CreateRoomReservation @userId, @amountPaid, @totalPrice, @isCancelled, @startDate, @endDate SET @reservationId = @@IDENTITY";
                cmd.Parameters.AddWithValue("@startDate", roomReservation.DateRange.Start);
                cmd.Parameters.AddWithValue("@endDate", roomReservation.DateRange.End);
                List<IReservedRoom> roomIds = roomReservation.ReservedRooms;
                int countCheck = 0;
                foreach (IReservedRoom rm in roomIds)
                {
                    int index = 0;
                    while(index < rm.Quantity)
                    {
                        string query = " INSERT INTO [ReservedRoom] (roomId,reservationId) VALUES (@roomId, @reservationId);";
                        cmd.Parameters.AddWithValue("@roomId", rm.RoomId);
                        cmd.CommandText += query;
                        index++;
                    }
                    countCheck += index;
                }
                if (countCheck != roomIds.Count)
                {
                    throw new Exception("A problem has occurred trying to make reservation.");
                }
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

        public List<ActivityReservation> GetAllReservationByActivity(int activityId)
        {
            string query = " SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, rm.startDate, rm.endDate, am.activitiesId, am.date FROM Reservation r " +
                "LEFT JOIN RoomReservation rm ON r.id = rm.id LEFT JOIN ActivitiesReservation am ON r.id = am.id WHERE am.activitiesId = @activityId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@activityId", activityId);
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservations = ReservationMapper.GetAllReservations(reader);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd is IDisposable diposable) { diposable.Dispose(); }
            }
            return reservations.Cast<ActivityReservation>().ToList();
        }
        public List<Reservation> GetAllReservationByMember(int userId)
        {
            string query = "SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, rm.startDate, rm.endDate, am.activitiesId, am.date FROM Reservation r " +
                "LEFT JOIN RoomReservation rm ON r.id = rm.id LEFT JOIN ActivitiesReservation am ON r.id = am.id WHERE r.userId = @userId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@userId", userId);
            List<Reservation> reservaions = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservaions = ReservationMapper.GetAllReservations(reader);
                foreach (RoomReservation roomReservation in reservaions)
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
            return reservaions;
        }

        public List<RoomReservation> GetAllReservationByRoom(int roomId)
        {
            string query = "SELECT DISTINCT * FROM [vwRoomReservation] WHERE roomId = @roomId";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@roomId", roomId);
            List<Reservation> roomReservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                roomReservations = ReservationMapper.GetAllReservations(reader);
                foreach(RoomReservation roomReservation in roomReservations)
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
            return roomReservations.Cast<RoomReservation>().ToList();
        }

        public Reservation GetReservationById(int id)
        {
            string query = "SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, rm.startDate, rm.endDate, am.activitiesId, am.date FROM Reservation r " +
                "left JOIN RoomReservation rm ON r.id = rm.id left JOIN ActivitiesReservation am ON r.id = am.id WHERE r.id = @reservationId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@reservationId", id);
            Reservation reservation;
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservation = ReservationMapper.GetReservation(reader);
                if (reservation.GetType() == typeof(RoomReservation))
                {
                    cmd.Connection.Close();
                    query = "SELECT COUNT(roomId), roomId FROM ReservedRoom WHERE reservationId = @reservationId  GROUP BY roomId";
                    cmd = new SqlCommand(query);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@reservationId", reservation.Id);
                    reader = dbConnection.GetFromDB(cmd);
                    ((RoomReservation)reservation).ReservedRooms = ReservationMapper.GetReservedRoom(reader);
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
            return reservation;
        }

        public void UpdateReservation(Reservation reservation)
        {
            string query = "UPDATE [Reservation] SET amountPaid = @amountPaid, totalPrice = @totalPrice, isCancelled = @isCancelled WHERE reservationId = @reservationId";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reservationId", reservation.Id);
            cmd.Parameters.AddWithValue("@amountPaid", reservation.TotalPaid);
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
    }
}
