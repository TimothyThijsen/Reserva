using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        //<div class="tileDisplay">
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
