using DataAccessLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
namespace Factory
{
    public  class ReservationManagerFactory
    {
        public static ReservationManager GetRoomReservationManager() 
        {
            return new ReservationManager(new RoomReservationDAL());
        } 
        public static ReservationManager GetActivityReservationManager() 
        {
            return new ReservationManager(new ActivityReservationDAL());
        }
    }
}
