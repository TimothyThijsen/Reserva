using DomainLayer.Interfaces;

namespace DomainLayer
{
    public class ActivitySchedule : ISchedule
    {
        List<Reservation> _activities;
        public void AddReservation(Reservation reservation)
        {
            _activities.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            _activities.RemoveAt(_activities.FindIndex(r => r.Id == reservation.Id));
        }
    }
}
