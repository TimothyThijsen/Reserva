using DataAccessLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
namespace Factory
{
    public  class ReservationManagerFactory
    {
        private static readonly Dictionary<ReservationType, Func<ReservationManager>> _factories =
        new Dictionary<ReservationType, Func<ReservationManager>>
        {
            { ReservationType.RoomReservation, () => new ReservationManager(new RoomReservationDAL()) },
            { ReservationType.ActivityReservation, () => new ReservationManager(new ActivityReservationDAL()) }//f maybe include mock
        };
        public static ReservationManager GetReservationManager(ReservationType type)
        {
            if (_factories.TryGetValue(type, out var factory))
            {
                return factory();
            }

            throw new ArgumentException("Invalid reservation type");
        }
    }
}
