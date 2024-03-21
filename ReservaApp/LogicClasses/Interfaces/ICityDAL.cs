using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface ICityDAL
    {
        List<City> GetAllCities();
        City GetCity(int cityId);
        void AddCity(City city);
        void UpdateCity(City city);
        void RemoveCity(int id);
    }
}
