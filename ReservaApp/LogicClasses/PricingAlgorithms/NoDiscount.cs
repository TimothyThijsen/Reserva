using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.PricingAlgorithms
{
    public class NoDiscount : IPricingAlgorithm
    {
        public decimal CalculatePriceOnDay(Room room, DateTime date)
        {
            return room.Price;
        }
    }
}
