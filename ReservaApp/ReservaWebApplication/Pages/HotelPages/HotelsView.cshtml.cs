using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelsViewModel : PageModel
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public CityManager cityManager  = new CityManager(new CityDAL());
        [BindProperty]
        public SearchModel? SearchModel { get; set; } = new SearchModel();
        public void OnGet()
        {
            HttpContext.Session.SetString("prev_page", "/HotelPages/HotelsView");
            if (HttpContext.Session.GetString("search_model") != null)
            {
                SearchModel = JsonConvert.DeserializeObject<SearchModel>(HttpContext.Session.GetString("search_model"));
            }
            SearchModel.Cities = cityManager.GetAllCities();
            Hotels = hotelManager.GetHotelsBySearchModel(SearchModel);
        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("search_model", JsonConvert.SerializeObject(SearchModel));
            return RedirectToPage("/HotelPages/HotelsView");
        }
        public IActionResult OnPostReset()
        {
            HttpContext.Session.Remove("search_model");
            return RedirectToPage("/HotelPages/HotelsView");
        }
    }
}
