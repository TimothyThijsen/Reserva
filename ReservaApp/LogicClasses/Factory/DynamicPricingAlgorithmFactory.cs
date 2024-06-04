using DomainLayer.Interfaces;
using DomainLayer.PricingAlgorithms;
using DomainLayer.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class DynamicPricingAlgorithmFactory
    {

        private static readonly Dictionary<string, IPricingAlgorithm> _pricingAlgorithms = new()
        {
            { "ReservaCurve",new ReservaCurve()},
            { "SeasonalNorthern",new SeasonalNorthern()},
            { "SeasonalSouthern",new SeasonalSouthern()},
            { "NoDiscount",new NoDiscount()},
            { "MinimalCurve",new MinimalCurve()}
        };
        public static IPricingAlgorithm GetAlgorithm(string algorithmType)
        {
            if (!_pricingAlgorithms.TryGetValue(algorithmType, out var algorithm))
            {
                throw new ArgumentException("Invalid algorithm type");
            }
            return algorithm;
        }
    }
}
