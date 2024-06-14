namespace DomainLayer
{
    public class ReservedRoom
    {
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        public ReservedRoom() { }
        public ReservedRoom(int quantity, int roomId)
        {
            Quantity = quantity;
            RoomId = roomId;
        }
    }
}
