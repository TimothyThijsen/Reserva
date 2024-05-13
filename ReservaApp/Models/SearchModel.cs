using System;
using System.Collections.Generic;
using System.Globalization;
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
        
        public DateTime GetStartDate (){
			return DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime GetEndDate()
        {
			return DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
		}
    }
}
