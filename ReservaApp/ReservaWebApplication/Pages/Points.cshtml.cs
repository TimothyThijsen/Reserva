using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages
{
    [Authorize(Roles = "premium_account")]
    public class PointsModel : PageModel
    {


        public void OnGet()
        {
        }
    }
}
