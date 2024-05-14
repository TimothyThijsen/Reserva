namespace DomainLayer.Interfaces
{
    public interface IHotelDAL
    {
        void AddHotel(Hotel hotel);
        void RemoveHotel(int id);
        void EditHotel(Hotel hotel);
        Hotel GetHotelById(int id);
        List<Hotel> GetAllHotels();
        Hotel GetHotelAndRoomsById(int id);
    }
}
