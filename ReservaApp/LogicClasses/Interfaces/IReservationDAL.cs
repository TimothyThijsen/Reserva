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
        List<Reservation> GetAllReservationByEntityId(int entityId);
        Reservation GetByReservationId(int id);
    }
}
