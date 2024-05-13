using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
