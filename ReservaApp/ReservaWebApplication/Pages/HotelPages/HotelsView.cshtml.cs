using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelsViewModel : PageModel
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public CityManager CityManager { get; set; } = new CityManager(new CityDAL());
        public void OnGet()
        {
            Hotels = hotelManager.GertAllHotels();
        }
    }
}
