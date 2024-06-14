using System.Reflection;

namespace DomainLayer
{
    public class ObjectValidator
    {
        public static bool HasNoEmptyFields(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                    continue;
                object value = property.GetValue(obj);

                if (value == null || (value is string && string.IsNullOrWhiteSpace((string)value)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

