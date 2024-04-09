using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ReservedRoom : IReservedRoom
    {
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        
    }
}
