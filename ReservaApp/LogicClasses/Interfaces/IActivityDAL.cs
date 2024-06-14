namespace DomainLayer.Interfaces
{
    public interface IActivityDAL
    {
        void AddActivity(Activity activity);
        void EditActivity(Activity activity);
        void RemoveActivity(Activity activity);
        List<Activity> GetAllActivities();
        List<Activity> GetAllActivitiesByCity(int cityId);
        Activity GetActivityById(int id);

    }
}
