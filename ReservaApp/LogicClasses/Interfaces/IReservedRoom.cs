using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IReservedRoom
    {
        public int Quantity { get; set; }
        public int RoomId { get; set; }
    }
}
