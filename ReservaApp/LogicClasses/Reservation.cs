using DomainLayer.Interfaces;
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
        private decimal totalPrice;
        private bool isCanceled;

        public int Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int AmountOfGuest {  get { return amountOfGuest; } }
        
        public decimal TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public bool IsCanceled {  get { return isCanceled; } }
        //public Reservation() { }
        public Reservation(int userId,int amountOfGuest, decimal totalPrice) 
        { 
            this.userId = userId;
            this.amountOfGuest = amountOfGuest;
            this.totalPrice = totalPrice;
            isCanceled = false;
        }

        public Reservation(int id, int userId, int amountOfGuest, decimal totalPrice, bool isCanceled) : this(userId,amountOfGuest,totalPrice)
        {
            this.id = id;
            this.isCanceled = isCanceled;
        }


        public void CancelReservation()
        {
            isCanceled = true;
        }


	}
}
