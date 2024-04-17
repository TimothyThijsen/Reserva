using DataAccessLayer;
using DomainLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.ConstrainedExecution;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelPageModel : PageModel
    {
        HotelManager hotelManager = new HotelManager(new HotelDAL());
        RoomManager roomManager = new RoomManager(new RoomDAL());
        public CityManager CityManager { get; set; } = new CityManager(new CityDAL());
        public List<Room> Rooms { get; set; }
        [BindProperty]
        public string StatusMessage { get; set; }
        [BindProperty]
        public List<IReservedRoom> ReservedRooms { get; set; } = new List<IReservedRoom>();
        public Hotel Hotel { get; set; }
		
		public void OnGet(int id, string statusMessage)
        {
            
            if (id> 0)
            {
                if (HttpContext.Session.GetInt32("hotel_id") != id)
                {
                    HttpContext.Session.SetInt32("hotel_id", id);
                }
            }
            else{
                id = (int)HttpContext.Session.GetInt32("hotel_id");
            }
            Rooms = roomManager.GetRoomByHotel(id);
            Hotel = hotelManager.GetHotelById(id);
            foreach (Room room in Rooms)
            {
                ReservedRooms.Add(new ReservedRoom(0, room.Id));
            }
            if (statusMessage != null)
            {
                StatusMessage = statusMessage.Trim();
            }
        }
        public IActionResult OnPost()
        {
            RoomReservation reservation;
			SearchModel searchModel = new SearchModel();
            DateTime endDate;
            DateTime startDate; 
            int countOfRooms = 0;
            decimal totalPrice = 0;
            foreach (ReservedRoom rm in ReservedRooms)
            {
                countOfRooms += rm.Quantity;
                totalPrice += roomManager.GetRoomById(rm.RoomId).Price * rm.Quantity;

            }
            if (countOfRooms < 1)
            {
                StatusMessage = "No room selected, please select a room to continue!";
                return RedirectToPage("/HotelPages/HotelPage", new {statusMessage = StatusMessage });
            }
			if (HttpContext.Session.GetString("search_model") != null)
			{
				searchModel = JsonConvert.DeserializeObject<SearchModel>(HttpContext.Session.GetString("search_model"));
                
			}
            if(searchModel.StartDate == null)
            {
                startDate = DateTime.Today;
                endDate = startDate.AddDays(3);
            }
            else
            {
                startDate = DateTime.ParseExact(searchModel.StartDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                endDate = DateTime.ParseExact(searchModel.EndDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            try
            {
                reservation = new RoomReservation(Convert.ToInt32(User.FindFirst("id").Value), searchModel.AmountOfGuests.Value != null ? searchModel.AmountOfGuests.Value : 2, 0, totalPrice, startDate, endDate);
                reservation.ReservedRooms = ReservedRooms;
                HttpContext.Session.SetString("reservation", JsonConvert.SerializeObject(reservation));
            }
            catch(Exception)
            {
                StatusMessage = "There seem to be a problem trying to add reservation request";
            }
            if(StatusMessage != null)
            {
                return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
            }
            
            return RedirectToPage("/HotelPages/Checkout");
        }
    }
}
