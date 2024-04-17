using DomainLayer;
using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapper
{
    public static class RoomReservationModelExtension
    {
        public static RoomReservation ToLogicLayer(this RoomReservationModel reservationModel)
        {
            RoomReservation reservation = new RoomReservation(reservationModel.UserId, reservationModel.AmountOfGuest, 0,reservationModel.TotalPrice, reservationModel.StartDate, reservationModel.EndDate);
            reservation.ReservedRooms = reservationModel.ReservedRooms.Cast<IReservedRoom>().ToList();
            return reservation;
        }
    }
}
