using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ReservaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        //<div class="tileDisplay">
        private readonly ILogger<IndexModel> _logger;
        public CityManager cityManager = new CityManager(new CityDAL());
        [BindProperty]
        public SearchModel SearchModel { get; set; } 
        public List<City> Cities { get; private set; } 
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {
            Cities = cityManager.GetAllCities();
            
        }
        public IActionResult OnPost() 
        {
            
            return RedirectToPage("Index");
        }
    }
}
