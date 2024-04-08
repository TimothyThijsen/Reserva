using DomainLayer.Interfaces;

namespace DomainLayer
{
    public class RoomSchedule : ISchedule
    {
        List<RoomReservation> scheduledReservations = new List<RoomReservation> ();
        public void AddReservation(RoomReservation reservation)
        {
            scheduledReservations.Add(reservation);
        }

        public bool IsAvailable(DateRange dateRange,Room room)
        {
            int countScheduled = 0;
            foreach (RoomReservation reservation in scheduledReservations)
            {
                //List<Room> reservedRoom = reservation.;
                //countScheduled += reservation.ReservedRooms.Where(r => r.Key == room.Id).Select(r => r.Value).ToList().Count();
                if (reservation.DateRange.Includes(dateRange))
                {
                    countScheduled += reservation.ReservedRooms.Where(r => r.Key == room.Id).Select(r => r.Value).ToList().Count();
                }
            }
            if(countScheduled >= room.Capacity) 
            {
                return false;
            }
            return true;
        }

        public void RemoveReservation(RoomReservation reservation)
        {
            scheduledReservations.Remove(reservation);
        }

    }
}
