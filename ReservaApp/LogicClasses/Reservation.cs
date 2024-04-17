using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Reservation
    {
        private int id, userId, amountOfGuest;
        private decimal totalPaid, totalPrice;
        private bool isCanceled;

        public int Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int AmountOfGuest {  get { return amountOfGuest; } }
        public decimal TotalPaid {  get { return totalPaid; } }
        public decimal TotalPrice {  get { return totalPrice; } }
        public bool IsCanceled {  get { return isCanceled; } }
        public Reservation(int userId,int amountOfGuest, decimal totalPaid, decimal totalPrice) 
        { 
            this.userId = userId;
            this.amountOfGuest = amountOfGuest;
            this.totalPaid = totalPaid;
            this.totalPrice = totalPrice;
            isCanceled = false;
        }

        public Reservation(int id, int userId, int amountOfGuest, decimal totalPaid, decimal totalPrice, bool isCanceled) : this(userId,amountOfGuest,totalPaid,totalPrice)
        {
            this.id = id;
            this.isCanceled = isCanceled;
        }

        public decimal GetAmountDue() 
        { 
            return totalPrice - totalPaid;
        }

        public void CancelReservation()
        {
            isCanceled = true;
        }


    }
}
