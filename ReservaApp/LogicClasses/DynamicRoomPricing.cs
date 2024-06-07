using DomainLayer.Interfaces;
using Factory;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class DynamicRoomPricing
    {
        TimeProvider timeProvider;
        public DynamicRoomPricing(TimeProvider timeProvider) 
        { 
            this.timeProvider = timeProvider;
        }
        public List<RoomDTO> CalculateRoomPrices(Hotel hotel, DateRange dateRange)
        {
            List<RoomDTO> roomsDTOList = new List<RoomDTO>();
            List<string> pricingAlgorithms = hotel.PricingAlgorithms.Split(", ").ToList();
            foreach (Room room in hotel.Rooms!)
            {
                decimal price = CalculateRoomPriceAverage(room, dateRange, pricingAlgorithms);
                roomsDTOList.Add(new RoomDTO(room.Id, room.Quantity, room.Name, room.HotelId,
                    price,
                    room.Capacity, room.BedType
                    ));
            }
            return roomsDTOList;
        }

        public decimal CalculateRoomPriceAverage(Room room, DateRange dateRange, List<string> pricingAlgorithms)
        {
            IPricingAlgorithm pricingAlgorithm;
            DynamicPricingAlgorithmFactory dynamicPricingAlgorithmFactory = new DynamicPricingAlgorithmFactory(timeProvider);
            decimal finalPrice = 0;
            for (DateTime dt = dateRange.Start; dt <= dateRange.End; dt = dt.AddDays(1))
            {
                decimal priceOnDay = room.Price;
                foreach(string name in pricingAlgorithms)
                {
                    pricingAlgorithm = dynamicPricingAlgorithmFactory.GetAlgorithm(name);
                    priceOnDay += pricingAlgorithm.CalculatePriceOnDay(room, dt);
                }
                finalPrice += priceOnDay;
            }
            return Decimal.Round((finalPrice / (dateRange.GetDaysCount() + 1)),2) ;
        }

        
    }
}
