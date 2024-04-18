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
    public class ActivityReservationDAL : IReservationDAL
    {
        IConnection dbConnection;
        public ActivityReservationDAL()
        {
            dbConnection = new DatabaseConnection();
        }
        public void CreateReservation(Reservation reservation)
        {
            ActivityReservation activityReservation = (ActivityReservation)reservation;
            string query = "INSERT INTO [Reservation] (userId, amountPaid, totalPrice, isCancelled, amountOfGuests) VALUES (@userId, @amountPaid, @totalPaid, @totalPrice, " +
                "@isCancelled); INSERT INTO [ActivitiesReservation] (id, activitiesId, date) VALUES (SCOPE_IDENTITY(), @activityId, @date)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@userId", activityReservation.UserId);
            cmd.Parameters.AddWithValue("@amountPaid", activityReservation.TotalPaid);
            cmd.Parameters.AddWithValue("@totalPrice", activityReservation.TotalPrice);
            cmd.Parameters.AddWithValue("@isCancelled", activityReservation.IsCanceled);
            cmd.Parameters.AddWithValue("@activityId", activityReservation.ActivityId);
            cmd.Parameters.AddWithValue("@date", activityReservation.Date);

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
            string query = "SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, am.activitiesId, am.date FROM Reservation r " +
                "LEFT JOIN ActivitiesReservation am ON r.id = am.id  WHERE r.userId = @userId and am.id IS NOT NULL";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@userId", userId);
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservations = ReservationMapper.GetAllActivityReservations(reader);

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
            string query = " SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, am.activitiesId, am.date FROM Reservation r " +
                "LEFT JOIN ActivitiesReservation am ON r.id = am.id WHERE am.activitiesId = @activityId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@activityId", entityId);
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservations = ReservationMapper.GetAllActivityReservations(reader);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd is IDisposable diposable) { diposable.Dispose(); }
            }
            return reservations.Cast<Reservation>().ToList();
        }

        public Reservation GetByReservationId(int id)
        {
            string query = "SELECT r.id, r.userId, r.amountPaid, r.totalPrice , r.isCanceled, r.amountOfGuests, am.activitiesId, am.date FROM Reservation r " +
                "left JOIN ActivitiesReservation am ON r.id = am.id WHERE r.id = @reservationId;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@reservationId", id);
            Reservation reservation;
            try
            {
                SqlDataReader reader = dbConnection.GetFromDB(cmd);
                reservation = ReservationMapper.GetActivityReservation(reader);
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
