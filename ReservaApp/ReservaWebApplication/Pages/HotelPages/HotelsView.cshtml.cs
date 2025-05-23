using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;
using ReservaWebApplication.Models;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelsViewModel : PageModel
    {
        HotelManager hotelManager;
        public CityManager cityManager;
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        [BindProperty]
        public SearchBarPartialModel SearchBarPartialModel { get; set; } = new SearchBarPartialModel();
        SearchModel? SearchModel { get; set; } = new SearchModel();
        public string StatusMessage { get; set; }
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
            SearchModel.Setup();
            SearchBarPartialModel.Cities = cityManager.GetAllCities();
            SearchBarPartialModel.SearchModel = SearchModel;
            Hotels = hotelManager.GetHotelsBySearchModel(SearchBarPartialModel.SearchModel);


        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("search_model", JsonConvert.SerializeObject(SearchBarPartialModel.SearchModel));
            return RedirectToPage("/HotelPages/HotelsView");
        }
        public IActionResult OnPostReset()
        {
            HttpContext.Session.Remove("search_model");
            return RedirectToPage("/HotelPages/HotelsView");
        }
    }
}
