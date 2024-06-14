namespace DomainLayer.Interfaces
{
    public interface ISchedule

    {
        void AddReservation(Reservation reservation);
        void RemoveReservation(Reservation reservation);

    }
}
