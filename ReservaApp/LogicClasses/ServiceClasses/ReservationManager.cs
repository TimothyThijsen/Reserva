using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interfaces;
namespace DomainLayer.ServiceClasses
{
    public class ReservationManager
    {
        IReservationDAL reservationDAL;
        public ReservationManager(IReservationDAL reservationDAL)
        {
            this.reservationDAL = reservationDAL;
        }
        public void CreateReservation(Reservation reservation)
        {
            reservationDAL.CreateReservation(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {
            reservationDAL.UpdateReservation(reservation);
        }
        public List<Reservation> GetAllReservationByMember(int userId) 
        { 
            return reservationDAL.GetAllReservationByMember(userId);
        }
        public List<RoomReservation> GetAllReservationByRoom(int roomId)
        {
            return reservationDAL.GetAllReservationByRoom(roomId);
        }
        public List<ActivityReservation> GetAllReservationByActivity(int activityId)
        {
            return reservationDAL.GetAllReservationByActivity(activityId);
        }
        public Reservation GetReservationById(int id) 
        { 
            return reservationDAL.GetReservationById(id);
        }
    }
}
