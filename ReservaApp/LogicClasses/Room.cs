namespace DomainLayer
{
    public class Room
    {
        int id, quantity, hotelId;
        string name;
        decimal price;
        Schedule schedule;
        
        public int Id { get { return id; } }
        public int Quantity {  get { return quantity; } }
        public string Name { get { return name; } }
        public int HotelId {  get { return hotelId; } }
        public decimal Price { get { return price; } }

        public Room(int hotelId, string name, int quantity,  decimal price)
        {
            this.quantity = quantity;
            this.name = name;
            this.price = price;
            this.hotelId = hotelId;
        }public Room(int id, int hotelId, string name, int quantity, decimal price) : this(hotelId, name, quantity, price)
        {
            this.id = id;
        }
    }
}
