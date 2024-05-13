using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ReservaWebApplication.Models;

namespace ReservaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public CityManager cityManager;
        [BindProperty]
        public SearchBarPartialModel SearchBarPartialModel { get; set; } = new SearchBarPartialModel();
        public SearchModel SearchModel { get; set; } = new SearchModel();
        public IndexModel(ILogger<IndexModel> logger, CityManager cityManager)
        {
            _logger = logger;
            this.cityManager = cityManager;
        }

        public void OnGet()
        {
            HttpContext.Session.Remove("prev_page");
            SearchBarPartialModel.Cities = cityManager.GetAllCities();
            SearchBarPartialModel.SearchModel = SearchModel;   
            
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
