namespace DomainLayer.Interfaces
{
    public interface IReservationDAL
    {
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservationByMember(int userId);
        List<Reservation> GetAllReservationByEntityId(int entityId);
        Reservation GetByReservationId(int id);
        int GetAvailability(DateRange dateRange, int entityId);
    }
}
