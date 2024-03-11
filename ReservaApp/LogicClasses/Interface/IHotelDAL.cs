namespace DomainLayer.Interface
{
    public interface IHotelDAL
    {
        void AddHotel(Hotel hotel);
        void RemoveHotel(Hotel hotel);
        void EditHotel(Hotel hotel);
        Hotel GetHotelById(int id);
        List<Hotel> GetAllHotels();
    }
}
