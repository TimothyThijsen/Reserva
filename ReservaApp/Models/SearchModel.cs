using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DomainLayer.Interfaces;


namespace Models
{
    public class SearchModel : ISearchModel
    {
        public int? CityId {  get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? AmountOfGuests { get; set; }
        public List<City>? Cities { get; set; }
        
        public DateRange GetDateRange()
        {
            string format = "dd/MM/yyyy";
            DateRange dr = new DateRange(
                DateTime.ParseExact(StartDate,format, CultureInfo.InvariantCulture),
                DateTime.ParseExact(EndDate, format, CultureInfo.InvariantCulture));
            return dr;
        }
    }
}
