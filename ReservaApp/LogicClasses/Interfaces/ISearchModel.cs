using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface ISearchModel
    {
        public int? CityId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? AmountOfGuests { get; set; }
    }
}
