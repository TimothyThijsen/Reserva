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
