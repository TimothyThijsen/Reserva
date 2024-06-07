using DomainLayer.ServiceClasses;
using Microsoft.Extensions.Time.Testing;
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
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        DateTime today;
        [TestInitialize]
        public void Setup()
        {
            today = DateTime.Today;
            _roomManager = new RoomManager(new MockRoomDAL());
            reservationManager = new ReservationManager(new MockReservationDAL());
            fakeTimeProvider.SetUtcNow(new DateTime(2024,06,06));
            drp = new DynamicRoomPricing(fakeTimeProvider);
            room = _roomManager.GetRoomById(1);
            room.Schedule.AddListOfReservations(reservationManager.GetAllReservationByRoomId(1));
        }
        //dates booked 1 = 0.2, 2 = 0.7, 3=0.5
        [TestMethod]
        public void Calculate3DaysPriceReservaCurve()
        {
            DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
            DateTime end =   new DateTime(2024, 06, 10, 11, 00, 00);
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start,end),new List<string> { "ReservaCurve"});
            decimal expectedPrice = 81.47m;
            Assert.AreEqual(expectedPrice, price);
        }
        [TestMethod]
        public void Calculate3DaysNoDiscount()
        {
            DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
            DateTime end =   new DateTime(2024, 06, 10, 11, 00, 00);
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "NoDiscount" });
            decimal expectedPrice = 100m;
            Assert.AreEqual(expectedPrice, price);
        }
        [TestMethod]
        public void Calculate3DaysPriceMinimalCurve()
        {
            DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
            DateTime end =   new DateTime(2024, 06, 10, 11, 00, 00);
            decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start,end), new List<string> { "MinimalCurve" });
            string expectedPrice = "86.82";
            Assert.AreEqual(expectedPrice, price.ToString("0.00"));
        }
    }
}
