using DomainLayer.ServiceClasses;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class DynamicPricingUT
    {
        private Room room;
        private RoomManager _roomManager;
        private ReservationManager reservationManager;
        private DynamicRoomPricing drp;
        DateTime today;
        [TestInitialize]
        public void Setup()
        {
            today = DateTime.Today;
            _roomManager = new RoomManager(new MockRoomDAL());
            reservationManager = new ReservationManager(new MockReservationDAL());
            drp = new DynamicRoomPricing();
            room = _roomManager.GetRoomById(1);
            room.Schedule.AddListOfReservations(reservationManager.GetAllReservationByRoomId(1));
        }
        //dates booked 1 = 0.2, 2 = 0.7, 3=0.5
        [TestMethod]
        public void Calculate4DaysPriceReservaCurve()
        {
            
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(new DateTime(today.Year, today.Month, today.Day +1 , 16,00,00), new DateTime(today.Year, today.Month,today.Day+4, 11,00,00)),new List<string> { "ReservaCurve"});
            string expectedPrice = "81.47";
            Assert.AreEqual(expectedPrice, price.ToString("0.00"));
        }
        [TestMethod]
        public void Calculate4DaysNoDiscount()
        {
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(new DateTime(today.Year, today.Month, today.Day + 1, 16, 00, 00), new DateTime(today.Year, today.Month, today.Day + 4, 11, 00, 00)), new List<string> { "NoDiscount" });
            decimal expectedPrice = 100m;
            Assert.AreEqual(expectedPrice, price);
        }
        [TestMethod]
        public void Calculate4DaysPriceMinimalCurve()
        {
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(new DateTime(today.Year, today.Month, today.Day + 1, 16, 00, 00), new DateTime(today.Year, today.Month, today.Day + 4, 11, 00, 00)), new List<string> { "MinimalCurve" });
            string expectedPrice = "86.82";
            Assert.AreEqual(expectedPrice, price.ToString("0.00"));
        }
    }
}
