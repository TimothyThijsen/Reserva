namespace UnitTesting.MockData
{
    public class MockRoomDAL : IRoomDAL
    {
        private readonly List<Room> _rooms = new List<Room>
        {
            new Room(1, 1,"RoomTest", 10, 100,2,"TestBedType")
        };
        public void AddRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void EditRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRoomsByHotel(int hotelId)
        {
            return _rooms.Where(r => r.HotelId == hotelId).ToList();
        }

        public List<Room> GetAllRoomsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public Room? GetRoomById(int id)
        {
            return _rooms.Find(r => r.Id == id);
        }

        public void RemoveRoom(int id)
        {
            throw new NotImplementedException();
        }
    }
}
