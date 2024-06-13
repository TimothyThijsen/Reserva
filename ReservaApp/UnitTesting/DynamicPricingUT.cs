using Microsoft.Extensions.Time.Testing;

namespace UnitTesting
{
	[TestClass]
	public class DynamicPricingUT
	{
		private Room room;
		private RoomManager _roomManager = new RoomManager(new MockRoomDAL());
		private ReservationManager reservationManager = new ReservationManager(new MockReservationDAL());
		private DynamicRoomPricing drp;
		FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
		[TestInitialize]
		public void Setup()
		{
			fakeTimeProvider.SetUtcNow(new DateTime(2024, 06, 06));
			drp = new DynamicRoomPricing(fakeTimeProvider, reservationManager);
			room = _roomManager.GetRoomById(1);
			room.Schedule.AddListOfReservations(reservationManager.GetAllReservationByRoomId(1));//fix
		}
		//dates booked 1 = 0.2, 2 = 0.7, 3=0.5
		[TestMethod]
		public void Calculate3DaysPriceReservaCurve()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "ReservaCurve" });
			decimal expectedPrice = 81.47m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysNoDiscount()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "NoDiscount" });
			decimal expectedPrice = 100m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysPriceMinimalCurve()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "MinimalCurve" });
			decimal expectedPrice = 86.82m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysPriceSeasonalNorthern()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "SeasonalNorthern" });
			decimal expectedPrice = 110m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysPriceSeasonalSouthern()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "SeasonalSouthern" });
			decimal expectedPrice = 90m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysPriceReservaCurveAndSeasonalNorthern()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "ReservaCurve", "SeasonalNorthern" });
			decimal expectedPrice = 91.47m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void Calculate3DaysPriceReservaCurveAndSeasonalSouthern()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			decimal price = drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "ReservaCurve", "SeasonalSouthern" });
			decimal expectedPrice = 71.47m;
			Assert.AreEqual(expectedPrice, price);
		}
		[TestMethod]
		public void NoneExistingAlgorithm()
		{
			DateTime start = new DateTime(2024, 06, 07, 16, 00, 00);
			DateTime end = new DateTime(2024, 06, 10, 11, 00, 00);
			Assert.ThrowsException<InvalidAlgorithmException>(() => drp.CalculateRoomPriceAverage(room, new DateRange(start, end), new List<string> { "FakeAlgorithm" }));
		}
	}
}
