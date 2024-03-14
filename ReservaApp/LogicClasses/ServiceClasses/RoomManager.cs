using DomainLayer.Interface;

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
    }
}
