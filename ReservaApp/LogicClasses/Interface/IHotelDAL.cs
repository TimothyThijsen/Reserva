using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicClasses.Interface
{
    public interface IHotelDAL
    {
        void AddHotel(Hotel hotel);
        void RemoveHotel(Hotel hotel);
        void EditHotel(Hotel hotel);
        Hotel GetHotelById(int id);
        List<Hotel> GetAllHotels();
    }
}
