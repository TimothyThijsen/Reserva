using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ServiceClasses
{
    public class CityManager
    {
        ICityDAL cityDAL;
        public CityManager(ICityDAL cityDAL) 
        { 
            this.cityDAL = cityDAL;
        }

        public void AddCity(City city) 
        { 
            cityDAL.AddCity(city);
        }

        public void RemoveCity(City city)
        {
            cityDAL.RemoveCity(city.Id);
        }
        public List<City> GetAllCities()
        {
            return cityDAL.GetAllCities();
        }public City GetCity(int cityId)
        {
            return cityDAL.GetCity(cityId);
        }
    }
}
