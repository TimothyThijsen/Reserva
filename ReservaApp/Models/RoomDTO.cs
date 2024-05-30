using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string BedType { get; set; }

        public RoomDTO(int id, int quantity, string name, int hotelId, decimal price, int capacity, string bedType) 
        { 
            Id = id;
            Quantity = quantity;
            Name = name;
            HotelId = hotelId;
            Price = price;
            Capacity = capacity;
            BedType = bedType;
        }
    }
}
