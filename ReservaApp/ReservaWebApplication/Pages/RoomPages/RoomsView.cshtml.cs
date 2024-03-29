using DataAccessLayer;
using DomainLayer.ServiceClasses;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ReservaWebApplication.Pages.RoomPages
{
    public class RoomsViewModel : PageModel
    {
        RoomManager roomManager = new RoomManager(new RoomDAL());
        [BindProperty]
        public List<Room> Rooms {  get; set; } = new List<Room>();
        public CityManager cityManager = new CityManager(new CityDAL());
        [BindProperty]
        public SearchModel SearchModel { get; set; }
        public List<City> Cities { get; private set; }
        public void OnGet()
        {
            Rooms = roomManager.GetAllRooms();
            Cities = cityManager.GetAllCities();
        }
    }
}
