using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            return reservationDAL.GetAllReservationByMember(userId); ;
        }
        public List<Reservation> GetAllReservationByRoomId(int roomId)
        {
            return reservationDAL.GetAllReservationByEntityId(roomId);
        }public List<Reservation> GetAllReservationByActivityId(int activityId)
        {
            return reservationDAL.GetAllReservationByEntityId(activityId);
        }
        public Reservation GetReservationById(int id) 
        {
            return reservationDAL.GetByReservationId(id);
        }
    }
}


