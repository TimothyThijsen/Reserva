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
        private List<ReservedRoom> reservedRooms;
        private DateRange dateRange;
        public List<ReservedRoom> ReservedRooms { get {  return reservedRooms; } set { reservedRooms = value; } }
        public DateRange DateRange { get { return dateRange; } }
        //public RoomReservation() { }
        public RoomReservation(int userId, int amountOfGuest, decimal totalPrice, DateTime startDate, DateTime endDate) : base(userId, amountOfGuest, totalPrice)
        {
            dateRange = new DateRange(startDate, endDate);
        }public RoomReservation(int id, int userId, int amountOfGuest, decimal totalPrice, bool isCanceled, DateTime startDate, DateTime endDate) : base(id,userId,amountOfGuest,totalPrice,isCanceled)
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

        public string GetRoomCount()
        {
            int roomCount = 0;
            foreach (ReservedRoom rm in reservedRooms)
            {
                roomCount += rm.Quantity;
            }
            if (roomCount <= 1)
            {
                return $"{roomCount} room";
            }
            return $"{roomCount} rooms";
        }

        public string GetAmountOfNights()
        {
            string text = string.Empty;
			TimeSpan timeSpan = dateRange.End.Date - dateRange.Start.Date;
            if (timeSpan <= TimeSpan.FromDays(1))
            {
                return $"{timeSpan.Days} night";
            }
            return $"{timeSpan.Days} nights";
		}
        public TimeSpan GetTimeSpan()
        {
            return dateRange.End.Date - dateRange.Start.Date;
        }  
	}
}
