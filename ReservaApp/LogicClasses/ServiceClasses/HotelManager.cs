using DomainLayer.Interfaces;
using System.Data.Common;

namespace DomainLayer.ServiceClasses
{
    public class HotelManager
    {
        IHotelDAL hotelDAL;
        public HotelManager(IHotelDAL hotelDAL)
        {
            this.hotelDAL = hotelDAL;
        }

        public void AddHotel(Hotel hotel)
        {
            hotelDAL.AddHotel(hotel);
        }

        public void EditHotel(Hotel hotel)
        {
            hotelDAL.EditHotel(hotel);
        }
        public void RemoveHotel(Hotel hotel)
        {
            hotelDAL.RemoveHotel(hotel);
        }
        public List<Hotel> GetAllHotels()
        {
            return hotelDAL.GetAllHotels();
        }
        public Hotel GetHotelById(int id)
        {
            return hotelDAL.GetHotelById(id);
        }
        public List<Hotel> GetHotelsBySearchModel(ISearchModel searchModel) 
        {
            //List<Hotel> searchResults = new List<Hotel>();
            List<Hotel> searchResults = GetAllHotels();
            if (searchModel.CityId != null) 
            { 
                List<Hotel> results = new List<Hotel>();
                foreach(Hotel hotel in searchResults)
                {
                    if (hotel.CityId.Equals(searchModel.CityId)) { results.Add(hotel);}
                }
                searchResults = results;
            }
            
            return searchResults;
        }
    }
}
