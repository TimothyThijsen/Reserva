using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ObjectValidator
    {
        public static bool HasNoEmptyFields(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
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

