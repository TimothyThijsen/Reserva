using DomainLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Mapper
{
    public class ActivityMapper
    {
        public static Activity GetActivity(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string name = Convert.ToString(reader["name"])!;
            string description = Convert.ToString(reader["description"])!;
            decimal price = Convert.ToDecimal(reader["price"])!;
            int cityId = Convert.ToInt32(reader["cityId"])!;
            int capacity = Convert.ToInt32(reader["capacity"]);
            string street = Convert.ToString(reader["street"])!;
            string postalCode = Convert.ToString(reader["postalCode"])!;
            return new Activity(id, cityId, capacity, name, description, price, new Address(street, postalCode));
        }

        public static List<Activity> GetActivities(SqlDataReader reader)
        {
            List<Activity> activities = new List<Activity>();
            while (reader.Read())
            {
                activities.Add(GetActivity(reader));
            }
            return activities;
        }
    }
}
