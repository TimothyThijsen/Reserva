using DomainLayer.Interfaces;

namespace DomainLayer.PricingAlgorithms
{
    public class NoDiscount : IPricingAlgorithm
    {
        public decimal CalculatePriceOnDay(Room room, DateTime date)
        {
            return 0;
        }
    }
}
