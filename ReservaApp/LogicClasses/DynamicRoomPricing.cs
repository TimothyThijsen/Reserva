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
        /*DateRange NextFiveDays;
        DateTime TwoWeeksAway;*/
        /*public DynamicRoomPricing() 
        {
            NextFiveDays = new DateRange(DateTime.Today, DateTime.Today.AddDays(5));
            TwoWeeksAway = DateTime.Today.AddDays(14);
        }*/
        const decimal highDemandIncreaseFactor = 0.2m;
        const decimal lowDemandDecreaseFactor = 0.2m;
        const decimal timeAdjustmentFactor = 0.06m;
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
            double roomPercentageBooked = room.GetBookedAmount(date) / room.Quantity;
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
            //double weeksUntilCheckIn = daysUntilDate / 7;
            //decimal timeAdjustment = room.Price * timeAdjustmentFactor * (decimal)weeksUntilCheckIn;
            /*if (roomPercentageBooked >= 0.8)
            {
                //high demand 
                decimal highDemandIncrease = room.Price * highDemandIncreaseFactor;
                priceOnDay = room.Price + highDemandIncrease;
                priceOnDay += timeAdjustment;
            }
            else if (roomPercentageBooked <= 0.20)
            {
                //low demand
                decimal lowDemandIncrease = room.Price * lowDemandDecreaseFactor;
                priceOnDay = room.Price - lowDemandIncrease;
                priceOnDay += timeAdjustment;
            }
            else
            {
                //regular demand
                priceOnDay = room.Price;
            }*/
            return priceOnDay;
        }
        public static decimal CalculateRoomPriceAverage(Room room, DateRange dateRange)
        {
            decimal price = CalculateRoomPrice(room, dateRange);
            return price/(dateRange.GetDaysCount()+1);
        }
    }
}
