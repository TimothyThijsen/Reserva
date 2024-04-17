using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class RoomReservation : Reservation
    {
        private List<IReservedRoom> reservedRooms;
        private DateRange dateRange;
        public List<IReservedRoom> ReservedRooms { get {  return reservedRooms; } set { reservedRooms = value; } }
        public DateRange DateRange { get { return dateRange; } }
        public RoomReservation(int userId, int amountOfGuest, decimal totalPaid, decimal totalPrice, DateTime startDate, DateTime endDate) : base(userId, amountOfGuest, totalPaid, totalPrice)
        {
            dateRange = new DateRange(startDate, endDate);
        }public RoomReservation(int id, int userId, int amountOfGuest, decimal totalPaid, decimal totalPrice, bool isCanceled, DateTime startDate, DateTime endDate) : base(id,userId,amountOfGuest,totalPaid,totalPrice,isCanceled)
        {
            dateRange = new DateRange(startDate, endDate);
        }

        public string GetCheckInTime()
        {
            return $"Your check in time is {DateRange.Start.TimeOfDay.ToString("HH: mm")}";
        }
        public string GetCheckoutTime()
        {
            return $"Your check out time is {DateRange.End.TimeOfDay.ToString("HH: mm")}";
        }

        public int GetRoomCount()
        {
            int roomCount = 0;
            foreach (IReservedRoom rm in reservedRooms)
            {
                roomCount += rm.Quantity;
            }
            return roomCount;
        }

        public int GetAmountOfNights()
        {
			TimeSpan timeSpan = dateRange.End.Date - dateRange.Start.Date;

			return timeSpan.Days;
		}

    }
}
