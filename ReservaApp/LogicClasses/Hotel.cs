using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace DomainLayer
{
    public class Hotel
    {
        private int id, cityId;
        private string name, description;
        //private double rating;
        private Address address;
        
        private List<Room> rooms;
        //private List<Rating> ratings;

        public int Id { get { return id; } }
        public int CityId { get { return cityId; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public Address Address { get { return address; } }
        //public double Rating { get { return rating; } }
        public List<Room> Rooms { get { return rooms; } set { rooms = value; } }
        public Hotel(string name,string description, int cityId, Address address)
        {
            this.name = name;
            this.description = description;
            this.cityId = cityId;
            this.address = address;


        }public Hotel(int id, string name,string description, int cityId, Address address) : this(name,description,cityId,address)
        {
            this.id = id;
        }
    }
}
