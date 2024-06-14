using DomainLayer;

namespace Models
{
    public class RoomReservationModel
    {
        public int UserId { get; set; }
        public int AmountOfGuest { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ReservedRoom> ReservedRooms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        /*public RoomReservationModel(int userId, int amountOfGuest, decimal totalPrice,List<ReservedRoom>reservedRooms, DateTime startDate, DateTime endDate) 
        {
            
        }*/

    }
}
