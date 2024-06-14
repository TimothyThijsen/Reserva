using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.Activities
{
    public class ActivitiesOverviewModel : PageModel
    {
        ActivitiesManager activitiesManager;
        public CityManager cityManager;
        public List<Activity> activitiesList; 
        public ActivitiesOverviewModel(ActivitiesManager activitiesManager, CityManager cityManager)
        {
            this.activitiesManager = activitiesManager;
            this.cityManager = cityManager;
        }
        public void OnGet()
        {
			activitiesList = activitiesManager.GetActivities();
        }
    }
}
