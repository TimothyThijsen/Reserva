using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ActivityReservation : Reservation
    {
        DateTime date;
        int activityId;
        public DateTime Date { get { return date; } }
        public int ActivityId { get { return activityId; } }
        public ActivityReservation(int userId, int amountOfGuest , decimal totalPrice, int activityId, DateTime date) : base(userId, amountOfGuest, totalPrice)
        {
            this.activityId = activityId;
            this.date = date;
        }

        public ActivityReservation(int id, int userId, int amountOfGuest, decimal totalPrice, bool isCanceled, int activityId, DateTime date) : base(id, userId, amountOfGuest, totalPrice, isCanceled)
        {
            this.activityId = activityId;
            this.date = date;
        }
    }
}
