using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IReservationDAL
    {
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservationByMember(int userId);
        List<RoomReservation> GetAllReservationByRoom(int roomId);
        List<ActivityReservation> GetAllReservationByActivity(int activityId);
        Reservation GetReservationById(int id);
    }
}
