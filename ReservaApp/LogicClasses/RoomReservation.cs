using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class RoomReservation : Reservation
    {
        private Dictionary<int, int> reservedRooms;
        private DateRange dateRange;
        public Dictionary<int, int> ReservedRooms { get {  return reservedRooms; } }
        public DateRange DateRange { get { return dateRange; } }
        public RoomReservation(int userId, int amountOfGuest, decimal totalPaid, decimal totalPrice, Dictionary<int, int> quantityOfRoom, DateTime startDate, DateTime endDate) : base(userId, amountOfGuest, totalPaid, totalPrice)
        {
            this.reservedRooms = quantityOfRoom;
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
    }
}
