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
        
        private List<int> rooms;
        private List<Rating> ratings;

        public int Id { get { return id; } }
        public int CityId { get { return cityId; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        //public double Rating { get { return rating; } }
        public List<int> Rooms { get { return rooms; } set { rooms = value; } }
        public Hotel(string name,string description, Address address)
        {

        }public Hotel(int id, string name,string description, Address address)
        {

        }
    }
}
