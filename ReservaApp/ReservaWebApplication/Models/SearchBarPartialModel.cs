using DomainLayer;
using Models;

namespace ReservaWebApplication.Models
{
	public class SearchBarPartialModel
	{
		public SearchModel SearchModel { get; set; }
		public List<City>? Cities { get; set; } = new List<City>();
	}
}
