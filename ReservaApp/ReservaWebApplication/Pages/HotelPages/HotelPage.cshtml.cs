using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelPageModel : PageModel
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        RoomManager roomManager = new RoomManager(new RoomDAL());
        public CityManager CityManager { get; set; } = new CityManager(new CityDAL());
        public List<Room> Rooms { get; set; }
        [BindProperty]
        public string StatusMessage { get; set; }
        [BindProperty]
        public List<ReservedRoom> ReservedRooms { get; set; } = new List<ReservedRoom>();
        public Hotel Hotel { get; set; }
        public void OnGet(int id, string statusMessage)
        {
            
            if (id> 0)
            {
                if (HttpContext.Session.GetInt32("hotel_id") != id)
                {
                    HttpContext.Session.SetInt32("hotel_id", id);
                }
            }
            else{
                id = (int)HttpContext.Session.GetInt32("hotel_id");
            }
            Rooms = roomManager.GetRoomByHotel(id);
            Hotel = hotelManager.GetHotelById(id);
            foreach (Room room in Rooms)
            {
                ReservedRooms.Add(new ReservedRoom(0, room.Id));
            }
            if (statusMessage != null)
            {
                StatusMessage = statusMessage.Trim();
            }
        }
        public IActionResult OnPost()
        {
            int countOfRooms = 0;
            foreach(ReservedRoom rm in ReservedRooms)
            {
                countOfRooms += rm.Quantity;
                
            }
            if (countOfRooms < 1)
            {
                StatusMessage = "No room selected, please select a room to continue!";
                return RedirectToPage("/HotelPages/HotelPage", new {statusMessage = StatusMessage });
            }
            HttpContext.Session.SetString("reserved_rooms", JsonConvert.SerializeObject(ReservedRooms));
            //HttpContext.Session.Remove("hotel_id");
            return RedirectToPage("/HotelPages/Checkout");
        }
    }
}
