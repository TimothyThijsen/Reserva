using DomainLayer.Interfaces;

namespace DomainLayer
{
    public class RoomSchedule : ISchedule
    {
        List<Reservation> scheduledReservations = new List<Reservation>();
        public void AddReservation(Reservation reservation)
        {
            scheduledReservations.Add(reservation);
        }
        public void AddListOfReservations(List<Reservation> reservations)
        {
            foreach (RoomReservation reservation in reservations)
            {
                AddReservation(reservation);
            }
        }
        public int GetAvailability(DateRange dateRange, Room room)
        {
            int countScheduled = 0;
            foreach (RoomReservation reservation in scheduledReservations)
            {
                if (reservation.DateRange.Includes(dateRange))
                {
                    countScheduled += reservation.ReservedRooms.Where(r => r.RoomId == room.Id).Sum(r => r.Quantity);
                }
            }
            return room.Quantity - countScheduled;
        }
        public int GetBookedAmount(DateTime date, Room room)
        {
            int countScheduled = 0;
            foreach (RoomReservation reservation in scheduledReservations)
            {
                if (reservation.DateRange.Includes(date))
                {
                    countScheduled += reservation.ReservedRooms.Where(r => r.RoomId == room.Id).Sum(r => r.Quantity);
                }
            }
            return countScheduled;
        }

        public void RemoveReservation(Reservation reservation)
        {
            scheduledReservations.Remove(reservation);
        }

    }
}
