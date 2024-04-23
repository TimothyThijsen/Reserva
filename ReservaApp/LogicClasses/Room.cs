namespace DomainLayer
{
    public class Room 
    {
        int id, quantity, hotelId, capacity;
        string name, bedType;
        decimal price;
        RoomSchedule? schedule;
        
        public int Id { get { return id; } }
        public int Quantity {  get { return quantity; } }
        public string Name { get { return name; } }
        public int HotelId {  get { return hotelId; } }
        public decimal Price { get { return price; } }
        public int Capacity {  get { return capacity; } }
        public string BedType {  get { return bedType; } }
        public RoomSchedule Schedule { get { return schedule; } }

        public Room(int hotelId, string name, int quantity,  decimal price, int capacity, string bedType)
        {
            this.quantity = quantity;
            this.name = name;
            this.price = price;
            this.hotelId = hotelId;
            this.capacity = capacity;
            this.bedType = bedType;
            this.schedule = new RoomSchedule();
        }public Room(int id, int hotelId, string name, int quantity, decimal price, int capacity, string bedType) : this(hotelId, name, quantity, price, capacity, bedType)
        {
            this.id = id;
        }

        public string GetPrice()
        {
            return price.ToString("0.00");
        }
        public int GetAvailability(DateRange dr)
        {
            return Schedule.GetAvailability(dr, this);
        }
    }
}
