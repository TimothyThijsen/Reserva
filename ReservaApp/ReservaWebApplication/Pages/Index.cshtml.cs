using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;
using ReservaWebApplication.Models;
using System.Collections.Generic;
using System;

namespace ReservaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public CityManager cityManager;
        HotelManager hotelManager;
        public List<Hotel> hotels;
        public List<City> cities;   
        [BindProperty]
        public SearchBarPartialModel SearchBarPartialModel { get; set; } = new SearchBarPartialModel();
        public SearchModel SearchModel { get; set; } = new SearchModel();
        public string StatusMessage { get; set; }
        public IndexModel(ILogger<IndexModel> logger, CityManager cityManager, HotelManager hotelManager)
        {
            _logger = logger;
            this.cityManager = cityManager;
            this.hotelManager = hotelManager;
        }

        public void OnGet()
        {
            HttpContext.Session.Remove("prev_page");
            try
            {
                cities = cityManager.GetAllCities();
                hotels = hotelManager.GetAllHotels();
                SearchBarPartialModel.Cities = cities.GetRange(0, cities.Count); ;
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            SearchBarPartialModel.SearchModel = SearchModel;
            
            int index = 4;
            hotels.RemoveRange(index, hotels.Count - index);
            cities.RemoveRange(index, cities.Count - index);
        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("search_model", JsonConvert.SerializeObject(SearchBarPartialModel.SearchModel));
            return RedirectToPage("/HotelPages/HotelsView");
        }
        public IActionResult OnPostReset()
        {
            HttpContext.Session.Remove("search_model");
            return RedirectToPage("/Index");
        }

    }
}
