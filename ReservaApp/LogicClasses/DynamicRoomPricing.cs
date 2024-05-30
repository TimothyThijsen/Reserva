using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public static class DynamicRoomPricing
    {
        public static decimal CalculateRoomPrice(Room room, DateRange dateRange) 
        {
            decimal finalPrice = 0;
            List<DateTime> dates = new List<DateTime>();
            
            for (DateTime dt = dateRange.Start; dt <= dateRange.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            foreach (DateTime dt in dates)
            {
                finalPrice += CalculatePricePerDay(room, dt);
            }
            
            return finalPrice;
        }

        public static decimal CalculatePricePerDay(Room room, DateTime date)
        {
            decimal priceOnDay = 0;
            double roomPercentageBooked = (double)room.GetBookedAmount(date) / room.Quantity;
            double daysUntilDate = (date - DateTime.Today).TotalDays;
            daysUntilDate = daysUntilDate > 0 ? daysUntilDate : 1;
            roomPercentageBooked = roomPercentageBooked > 0 ? roomPercentageBooked : 0.1;
            if (daysUntilDate<= 140)
            {
                priceOnDay = room.Price * (decimal)(1.12 - roomPercentageBooked / 10 - (2 / ((-0.375 * roomPercentageBooked + 2.6735) + daysUntilDate))) * (decimal)(Math.Sqrt((-0.006 * (daysUntilDate) + 1.08) + roomPercentageBooked));
            }
            else
            {
                priceOnDay = (room.Price * 0.8m) + (decimal)(12.5 * roomPercentageBooked + 8.75);
            }
           
            if(priceOnDay < (room.Price*0.6m))
            {
                priceOnDay = room.Price * 0.6m;
            }
            if(priceOnDay < (room.Price * 0.8m) && daysUntilDate > 15)
            {
                priceOnDay = room.Price * 0.8m;
            }
            if(priceOnDay > (room.Price * 1.4m))
            {
                priceOnDay = room.Price * 1.4m;
            }
            priceOnDay += GetSeasonalRate(date,room);
            return priceOnDay;
        }

        public static decimal GetSeasonalRate(DateTime date, Room room)
        {
            int month = date.Month;

            if (month >= 11 || month <= 3)
            {
                return -(room.Price * 0.1m);
            }
            else if (month >= 5 && month <= 9)
            {
                return room.Price * 0.1m;
            }
            return 0;
        }
        public static decimal CalculateRoomPriceAverage(Room room, DateRange dateRange)
        {
            decimal price = CalculateRoomPrice(room, dateRange);
            return price/(dateRange.GetDaysCount()+1);
        }
    }
}
