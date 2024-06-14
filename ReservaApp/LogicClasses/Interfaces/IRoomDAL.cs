namespace DomainLayer.Interfaces
{
    public interface IRoomDAL
    {
        void AddRoom(Room room);
        void EditRoom(Room room);
        void RemoveRoom(int id);
        List<Room> GetAllRooms();
        List<Room> GetAllRoomsByLocation(string location);
        List<Room> GetAllRoomsByHotel(int hotelId);
        Room? GetRoomById(int id);
    }
}
