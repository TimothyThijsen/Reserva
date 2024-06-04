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
    public static class DynamicRoomPricing
    {
        public static List<RoomDTO> CalculateRoomPrices(Hotel hotel, DateRange dateRange)
        {
            List<RoomDTO> roomsDTOList = new List<RoomDTO>();
            foreach (Room room in hotel.Rooms)
            {
                decimal price = CalculateRoomPriceAverage(room, dateRange, hotel.PricingAlgorithms.Split(", ").ToList());
                roomsDTOList.Add(new RoomDTO(room.Id, room.Quantity, room.Name, room.HotelId,
                    price,
                    room.Capacity, room.BedType
                    ));
            }
            return roomsDTOList;
        }

        public static decimal CalculateRoomPriceAverage(Room room, DateRange dateRange, List<string> pricingAlgorithms)
        {
            
            IPricingAlgorithm pricingAlgorithm;
            decimal finalPrice = 0;
            List<DateTime> dates = new List<DateTime>();

            for (DateTime dt = dateRange.Start; dt <= dateRange.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            foreach (DateTime dt in dates)
            {
                decimal priceOnDay = room.Price;
                foreach(string name in pricingAlgorithms)
                {
                    pricingAlgorithm = DynamicPricingAlgorithmFactory.GetAlgorithm(name);
                    priceOnDay += pricingAlgorithm.CalculatePriceOnDay(room, dt);
                }
                finalPrice += priceOnDay;
            }

            return finalPrice / (dateRange.GetDaysCount() + 1);
        }

        
    }
}
