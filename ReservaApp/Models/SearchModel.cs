using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;


namespace Models
{
    public class SearchModel
    {
        public int? CityId {  get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? AmountOfGuests { get; set; }
        public List<City>? Cities { get; set; }
 
    }
}
