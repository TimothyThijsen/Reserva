using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DomainLayer.PricingAlgorithms
{
    public class ReservaCurve : IPricingAlgorithm
    {
        
        TimeProvider timeProvider;
        public ReservaCurve(TimeProvider timeProvider) 
        {
            this.timeProvider = timeProvider;
        }
        public decimal CalculatePriceOnDay(Room room, DateTime date)
        {
            decimal priceOnDay = 0;
            double roomPercentageBooked = (double)room.GetBookedAmount(date) / room.Quantity;
            TimeSpan spanOfDays = date - timeProvider.GetLocalNow();
            int daysUntilDate = spanOfDays.Days;
            daysUntilDate = daysUntilDate >= 1 ? daysUntilDate : 1;
            roomPercentageBooked = roomPercentageBooked > 0 ? roomPercentageBooked : 0.1;
            if (daysUntilDate <= 140)
            {
                priceOnDay = room.Price * (decimal)(1.12 - (roomPercentageBooked / 10) - (2 / ((-0.075 * roomPercentageBooked + 2.8375) + daysUntilDate))) * (decimal)(Math.Sqrt(((-0.008 * (daysUntilDate) + 1.08) + roomPercentageBooked)));
            }
            else
            {
                priceOnDay = (room.Price * 0.8m) + (decimal)(12.5 * roomPercentageBooked + 8.75);
            }
            //checks if calculated price in allowed range of discount.
            if (priceOnDay < (room.Price * 0.7m))
            {
                priceOnDay = room.Price * 0.7m;
            }
            if (priceOnDay < (room.Price * 0.8m) && daysUntilDate > 15)
            {
                priceOnDay = room.Price * 0.8m;
            }
            if (priceOnDay > (room.Price * 1.4m))
            {
                priceOnDay = room.Price * 1.4m;
            }
            return priceOnDay - room.Price;
        }
    }
}
