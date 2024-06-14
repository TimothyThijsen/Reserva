namespace UnitTesting.MockData
{
    public class MockHotelDAL : IHotelDAL
    {
        private List<Hotel> hotelList = new List<Hotel>
        {
        new Hotel(1, "HotelTest","HotelTest description", 1, new Address("street", "1234AB"),"ReservaCurve")
        };


        public void AddHotel(Hotel hotel)
        {
            hotelList.Add(hotel);
        }

        public void EditHotel(Hotel hotel)
        {
            hotelList[hotelList.IndexOf(hotelList.Find(h => h.Id == hotel.Id))] = hotel;
        }

        public List<Hotel> GetAllHotels()
        {
            return hotelList;
        }

        public Hotel GetHotelAndRoomsById(int id)
        {
            throw new NotImplementedException();
        }

        public Hotel GetHotelById(int id)
        {
            return hotelList.Find(h => h.Id == id);
        }

        public void RemoveHotel(int id)
        {
            hotelList.Remove(hotelList.Find(h => h.Id == id));
        }
    }
}
