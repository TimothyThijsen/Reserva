using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelPageModel : PageModel
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        RoomManager roomManager = new RoomManager(new RoomDAL());
        public CityManager CityManager { get; set; } = new CityManager(new CityDAL());
        public List<Room> Rooms { get; set; }
        [BindProperty]
        public List<ReservedRoom> ReservedRooms { get; set; } = new List<ReservedRoom>();
        public Hotel Hotel { get; set; }
        public void OnGet(int id)
        {
            if (id > 0)
            {
                Rooms = roomManager.GetRoomByHotel(id);
                Hotel = hotelManager.GetHotelById(id);
            }
            foreach (Room room in Rooms)
            {
                ReservedRooms.Add(new ReservedRoom(0, room.Id));
            }
        }
    }
}
