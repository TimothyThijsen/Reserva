using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ServiceClasses
{
	public class ActivitiesManager
	{
		IActivityDAL activityDAL;
		public ActivitiesManager(IActivityDAL activityDAL) 
		{ 
			this.activityDAL = activityDAL;
		}
		public void AddActivity(Activity activity)
		{
			activityDAL.AddActivity(activity);
		}
		public void RemoveActivity(Activity activity) 
		{
			activityDAL.RemoveActivity(activity);
		}
		public void EditActivity(Activity activity)
		{
			activityDAL.EditActivity(activity);
		}
		public Activity GetActivityById(int id) {
			return activityDAL.GetActivityById(id);
		}
		public List<Activity> GetActivities()
		{
			return activityDAL.GetAllActivities();
		}
		public List<Activity> GetActivitiesByCity(int cityId)
		{
			return activityDAL.GetAllActivitiesByCity(cityId);
		}
	}
}
