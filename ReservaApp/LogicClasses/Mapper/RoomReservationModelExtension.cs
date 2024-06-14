using DomainLayer;

namespace Models.Mapper
{
    public static class RoomReservationModelExtension
    {
        public static RoomReservation ToLogicLayer(this RoomReservationModel reservationModel)
        {
            RoomReservation reservation = new RoomReservation(reservationModel.UserId, reservationModel.AmountOfGuest, reservationModel.TotalPrice, reservationModel.StartDate, reservationModel.EndDate);
            reservation.ReservedRooms = reservationModel.ReservedRooms.Cast<ReservedRoom>().ToList();
            return reservation;
        }
    }
}
