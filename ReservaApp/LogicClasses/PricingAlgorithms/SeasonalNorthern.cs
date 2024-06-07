using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.PricingAlgorithms
{
    public class SeasonalNorthern : IPricingAlgorithm
    {
        TimeProvider timeProvider;
        public SeasonalNorthern(TimeProvider timeProvider) { this.timeProvider = timeProvider; }
        public decimal CalculatePriceOnDay(Room room, DateTime date)
        {

            int month = timeProvider.GetLocalNow().Month;

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
    }
}
