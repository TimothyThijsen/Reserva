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
        public static IPricingAlgorithm GetAlgorithm(string algorithmType)
        {
            switch (algorithmType)
            {
                case "ReservaCurve":
                    return new ReservaCurve();
                case "SeasonalNorthern":
                    return new SeasonalNorthern();
                default:
                    throw new ArgumentException("Invalid algorithm type");
            }

            
        }
    }
}
