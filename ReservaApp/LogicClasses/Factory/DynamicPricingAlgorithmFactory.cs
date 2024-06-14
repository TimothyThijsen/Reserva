using DomainLayer.Exceptions;
using DomainLayer.Interfaces;
using DomainLayer.PricingAlgorithms;

namespace Factory
{
    public class DynamicPricingAlgorithmFactory
    {
        TimeProvider timeProvider;

        private readonly Dictionary<string, IPricingAlgorithm> _pricingAlgorithms;
        public DynamicPricingAlgorithmFactory(TimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
            _pricingAlgorithms = new()
            {
                { "ReservaCurve",new ReservaCurve(timeProvider)},
                { "SeasonalNorthern",new SeasonalNorthern(timeProvider)},
                { "SeasonalSouthern",new SeasonalSouthern(timeProvider)},
                { "NoDiscount",new NoDiscount()},
                { "MinimalCurve",new MinimalCurve(timeProvider)}
            };
        }

        public IPricingAlgorithm GetAlgorithm(string algorithmType)
        {
            if (!_pricingAlgorithms.TryGetValue(algorithmType, out var algorithm))
            {
                throw new InvalidAlgorithmException();
            }
            return algorithm;
        }
    }
}
