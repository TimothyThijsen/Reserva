using DataAccessLayer;
using DomainLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelsViewModel : PageModel
    {
        HotelManager hotelManager;
        public CityManager cityManager;
        ReservationManager reservationManager = ReservationManagerFactory.GetReservationManager(ReservationType.RoomReservation);
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        [BindProperty]
        public SearchModel? SearchModel { get; set; } = new SearchModel();
        public HotelsViewModel(HotelManager hotelManager, CityManager cityManager)
        {
            this.hotelManager = hotelManager;
            this.cityManager = cityManager;
        }
        public void OnGet()
        {
            
            HttpContext.Session.SetString("prev_page", "/HotelPages/HotelsView");
            if (HttpContext.Session.GetString("search_model") != null)
            {
                SearchModel = JsonConvert.DeserializeObject<SearchModel>(HttpContext.Session.GetString("search_model"));
            }
            SearchModel.Cities = cityManager.GetAllCities();
            
			if (SearchModel.StartDate == null)
			{
                SearchModel.StartDate = DateTime.Today.ToString("dd/MM/yyyy");
                SearchModel.EndDate = DateTime.Today.ToString("dd/MM/yyyy");
            }
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
