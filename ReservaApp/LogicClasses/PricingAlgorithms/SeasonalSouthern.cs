using DomainLayer.Interfaces;

namespace DomainLayer.PricingAlgorithms
{
    public class SeasonalSouthern : IPricingAlgorithm
    {
        TimeProvider timeProvider;
        public SeasonalSouthern(TimeProvider timeProvider) { this.timeProvider = timeProvider; }
        public decimal CalculatePriceOnDay(Room room, DateTime date)
        {
            int month = timeProvider.GetLocalNow().Month;

            if (month >= 11 || month <= 3)
            {
                return room.Price * 0.1m;
            }
            else if (month >= 6 && month <= 8)
            {
                return -(room.Price * 0.1m);
            }
            return 0;
        }
    }
}
