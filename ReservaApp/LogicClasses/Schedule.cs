using DomainLayer.Interfaces;

namespace DomainLayer
{
    public class Schedule : ISchedule
    {
        List<Reservation> scheduledReservations = new List<Reservation> ();
        public void AddReservation(Reservation reservation)
        {
            scheduledReservations.Add(reservation);
        }

        public bool GetAvailability(DateRange dateRange)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservation(Reservation reservation)
        {
            scheduledReservations.Remove(reservation);
        }

    }
}
