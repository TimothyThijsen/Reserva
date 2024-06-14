using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.Activities
{
    public class ActivitiesOverviewModel : PageModel
    {
        ActivitiesManager activitiesManager;
        public ActivitiesOverviewModel(ActivitiesManager activitiesManager)
        {
            this.activitiesManager = activitiesManager;
        }
        public void OnGet()
        {

        }
    }
}
