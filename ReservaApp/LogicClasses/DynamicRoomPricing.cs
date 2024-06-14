using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Factory;
using Models;

namespace DomainLayer
{
    public class DynamicRoomPricing
    {
        TimeProvider timeProvider;
        ReservationManager roomReservationManager;
        public DynamicRoomPricing(TimeProvider timeProvider, ReservationManager roomReservationManager)
        {
            this.timeProvider = timeProvider;
            this.roomReservationManager = roomReservationManager;
        }
        public List<RoomDTO> CalculateRoomPrices(Hotel hotel, DateRange dateRange)
        {
            List<RoomDTO> roomsDTOList = new List<RoomDTO>();
            List<string> pricingAlgorithms = hotel.PricingAlgorithms.Split(", ").ToList();
            foreach (Room room in hotel.Rooms!)
            {
                room.Schedule.AddListOfReservations(roomReservationManager.GetAllReservationByRoomId(room.Id));
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
            //will loop trough every date in dateRange
            for (DateTime dt = dateRange.Start; dt <= dateRange.End; dt = dt.AddDays(1))
            {
                decimal priceOnDay = room.Price;
                foreach (string name in pricingAlgorithms)//loops trough all pricingAlgorithms
                {
                    pricingAlgorithm = dynamicPricingAlgorithmFactory.GetAlgorithm(name);
                    priceOnDay += pricingAlgorithm.CalculatePriceOnDay(room, dt);//calculates price differences
                }
                finalPrice += priceOnDay;//Adds the calculated differences to base price
            }
            return Decimal.Round((finalPrice / (dateRange.GetDaysCount() + 1)), 2);//rounds result to 2 points
        }


    }
}
