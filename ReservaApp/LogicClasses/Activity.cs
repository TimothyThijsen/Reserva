namespace DomainLayer
{
    public class Activity
    {
        int id, cityId, capacity;
        string name, description;
        decimal price;
        Address address;
        ActivitySchedule schedule;

        public int Id { get { return id; } }
        public int CityId { get { return cityId; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public decimal Price { get { return price; } }
        public int Capacity { get { return capacity; } }
        public Address Address { get { return address; } }
        public ActivitySchedule Schedule { get { return schedule!; } }

        public Activity(int cityId, int capacity, string name, string description, decimal price, Address address)
        {
            this.cityId = cityId;
            this.capacity = capacity;
            this.name = name;
            this.description = description;
            this.price = price;
            this.address = address;
            this.schedule = new ActivitySchedule();
        }
        public Activity(int id, int cityId, int capacity, string name, string description, decimal price, Address address) : this(cityId, capacity, name, description, price, address)
        {
            this.id = id;
        }
    }
}
