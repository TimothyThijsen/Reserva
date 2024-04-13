using DataAccessLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
namespace Factory
{
    public  class ReservationManagerFactory
    {
        public static ReservationManager GetReservationManager(ReservationType type)
        {
            switch (type)
            {
                case ReservationType.RoomReservation:
                    return new ReservationManager(new RoomReservationDAL());
                case ReservationType.ActivityReservation:
                    return new ReservationManager(new ActivityReservationDAL());
                default:
                    throw new ArgumentException("Invalid reservation type");
            }
        }
    }
}
