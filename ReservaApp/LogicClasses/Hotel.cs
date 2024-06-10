using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Models;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace DomainLayer
{
    public class Hotel
    {
        private int id, cityId;
        private string name, description, pricingAlgorithms;
        //private double rating;
        private Address address;
        private List<Room>? rooms;
        //private List<Rating> ratings;
        public int Id { get { return id; } }
        public int CityId { get { return cityId; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public string PricingAlgorithms { get { return pricingAlgorithms; } }
        public Address Address { get { return address; } }
        //public double Rating { get { return rating; } }
        public List<Room>? Rooms { get { return rooms; } set { rooms = value; } }
        public Hotel(string name,string description, int cityId, Address address, string pricingAlgorithms)
        {
            this.name = name;
            this.description = description;
            this.cityId = cityId;
            this.address = address;
            this.pricingAlgorithms = pricingAlgorithms;
        }public Hotel(int id, string name,string description, int cityId, Address address, string pricingAlgorithms) : this(name,description,cityId,address,pricingAlgorithms)
        {
            this.id = id;
        }
        public List<RoomDTO> GetRoomPrices(DateRange dateRange, DynamicRoomPricing dynamicRoomPricing)
        {
            List<RoomDTO> roomsList = new List<RoomDTO>();
            roomsList = dynamicRoomPricing.CalculateRoomPrices(this, dateRange);
            return roomsList;
        }
    }
}
