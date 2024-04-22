using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ActivityReservation : Reservation
    {
        public DateTime Date { get; set; }
        public int Id {  get; set; }
        public int ActivityId {  get; set; }
        public ActivityReservation(int userId, int amountOfGuest , decimal totalPrice) : base(userId, amountOfGuest, totalPrice)
        {
        }

        public ActivityReservation(int id, int userId, int amountOfGuest, decimal totalPrice, bool isCanceled) : base(id, userId, amountOfGuest, totalPrice, isCanceled)
        {
        }
    }
}
