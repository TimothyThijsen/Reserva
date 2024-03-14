using DomainLayer.Interface;

namespace DomainLayer.ServiceClasses
{
    public class HotelManager
    {
        IHotelDAL hotelDAL;
        public HotelManager(IHotelDAL hotelDAL)
        {
            this.hotelDAL = hotelDAL;
        }

        public void AddHotel(Hotel hotel)
        {
            hotelDAL.AddHotel(hotel);
        }

        public void EditHotel(Hotel hotel)
        {
            hotelDAL.EditHotel(hotel);
        }
        public void RemoveHotel(Hotel hotel)
        {
            hotelDAL.RemoveHotel(hotel);
        }
        public List<Hotel> GertAllHotels()
        {
            return hotelDAL.GetAllHotels();
        }
        public Hotel GetHotelById(int id)
        {
            return hotelDAL.GetHotelById(id);
        }
    }
}
