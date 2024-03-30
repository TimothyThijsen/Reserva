using DataAccessLayer;
using DomainLayer.ServiceClasses;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;

namespace ReservaWebApplication.Pages.RoomPages
{
    public class RoomsViewModel : PageModel
    {
        RoomManager roomManager = new RoomManager(new RoomDAL());
        [BindProperty]
        public List<Room> Rooms {  get; set; } = new List<Room>();
        public CityManager cityManager = new CityManager(new CityDAL());
        [BindProperty]
        public SearchModel SearchModel { get; set; } = new SearchModel();
        //public List<City> Cities { get; private set; }
        public void OnGet()
        {
            Rooms = roomManager.GetAllRooms();
            //Cities = cityManager.GetAllCities();
            if(HttpContext.Session.GetString("search_model") != null)
            {
                SearchModel = JsonConvert.DeserializeObject<SearchModel>(HttpContext.Session.GetString("search_model"));
            }
            SearchModel.Cities = cityManager.GetAllCities();
            

        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("search_model", JsonConvert.SerializeObject(SearchModel));
            return RedirectToPage("/RoomPages/RoomsView");
        }
        public IActionResult OnPostReset()
        {
            HttpContext.Session.Remove("search_model");
            return RedirectToPage("/RoomPages/RoomsView");
        }
    }
}
