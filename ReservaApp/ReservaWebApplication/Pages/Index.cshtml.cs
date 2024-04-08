using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ReservaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        //<div class="tileDisplay">
        private readonly ILogger<IndexModel> _logger;
        public CityManager cityManager = new CityManager(new CityDAL());
        [BindProperty]
        public SearchModel SearchModel { get; set; } = new SearchModel();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {
            SearchModel.Cities = cityManager.GetAllCities();
            
        }
        public IActionResult OnPost() 
        {
            HttpContext.Session.SetString("search_model", JsonConvert.SerializeObject(SearchModel));
            return RedirectToPage("/HotelPages/HotelsView");
        }
        public IActionResult OnPostReset()
        {
            HttpContext.Session.Remove("search_model");
            return RedirectToPage("/Index");
        }

    }
}
