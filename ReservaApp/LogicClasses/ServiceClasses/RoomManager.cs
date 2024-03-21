using DomainLayer.Interfaces;

namespace DomainLayer.ServiceClasses
{
    public class RoomManager
    {
        IRoomDAL roomDAL;
        public RoomManager(IRoomDAL roomDAL)
        {
            this.roomDAL = roomDAL;
        }

        public void AddRoom(Room room)
        {
            roomDAL.AddRoom(room);
        }

        public void EditRoom(Room room)
        {
            roomDAL.EditRoom(room);
        }
        public void RemoveRoom(int id)
        {
            roomDAL.RemoveRoom(id);
        }
        public List<Room> GetAllRooms()
        {
            return roomDAL.GetAllRooms();
        }
        public Room GetRoomById(int id)
        {
            return roomDAL.GetRoomById(id);
        }
        public List<Room> GetRoomByHotel(int hotelId)
        {
            return roomDAL.GetAllRoomsByHotel(hotelId);
        }
    }
}
