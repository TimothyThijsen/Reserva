using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace UnitTesting
{
    [TestClass]
    public class HotelUT
    {
        private HotelManager _hotelManager;
        private readonly Bogus.Faker faker = new Bogus.Faker("uk");

        [TestInitialize]
        public void Setup()
        {
            _hotelManager = new HotelManager(new MockHotelDAL());
        }

        [TestMethod]
        public void AddHotel_ValidHotel_ShouldSucceed()
        {
            Hotel hotel = new Hotel(1, faker.Company.CompanyName(),faker.Lorem.Paragraph(), 1, new Address(faker.Person.Address.Street,faker.Person.Address.ZipCode));
            
            _hotelManager.AddHotel(hotel);

            Assert.IsTrue(_hotelManager.GetAllHotels().Contains(hotel));
            Assert.AreEqual(1,_hotelManager.GetAllHotels().Count);
        }

        [TestMethod]
        public void EditHotel_ValidHotel_ShouldSucceed()
        {
            Hotel hotel = new Hotel(1, faker.Company.CompanyName(), faker.Lorem.Paragraph(), 1, new Address(faker.Person.Address.Street, faker.Person.Address.ZipCode));
            _hotelManager.AddHotel(hotel);
            Hotel editHotel = new Hotel(1, "Grand hotel", faker.Lorem.Paragraph(), 1, new Address(faker.Person.Address.Street, faker.Person.Address.ZipCode));
            _hotelManager.EditHotel(editHotel);
            
            Assert.AreEqual("Grand hotel", _hotelManager.GetHotelById(hotel.Id).Name);
        }

        [TestMethod]
        public void RemoveHotel_ValidHotel_ShouldSucceed()
        {
            List<Hotel> hotelList = new List<Hotel>();
            hotelList.Add(new Hotel(1, faker.Company.CompanyName(), faker.Lorem.Paragraph(), 1, new Address(faker.Person.Address.Street, faker.Person.Address.ZipCode)));
            hotelList.Add(new Hotel(2, faker.Company.CompanyName(), faker.Lorem.Paragraph(), 1, new Address(faker.Person.Address.Street, faker.Person.Address.ZipCode)));
            foreach(Hotel hotel in hotelList)
            {
                _hotelManager.AddHotel(hotel);
            }
            Assert.AreEqual(2, _hotelManager.GetAllHotels().Count);
            _hotelManager.RemoveHotel(2);

            Assert.IsNull(_hotelManager.GetAllHotels().Find(h => h.Id == 2));
            Assert.IsNotNull(_hotelManager.GetAllHotels().Find(h => h.Id == 1));
            Assert.AreEqual(1, _hotelManager.GetAllHotels().Count);
        }
        
       

    }
}
