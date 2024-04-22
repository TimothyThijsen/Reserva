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
        HotelManager hotelManager;
        RoomManager roomManager;
        public CityManager cityManager;
        public List<Room> Rooms { get; set; }
        [BindProperty]
        public string StatusMessage { get; set; }
        [BindProperty]
        public List<ReservedRoom> ReservedRooms { get; set; } = new List<ReservedRoom>();
        public HotelPageModel(HotelManager hotelManager, RoomManager roomManager, CityManager cityManager) 
        { 
            this.hotelManager = hotelManager;
            this.roomManager = roomManager;
            this.cityManager = cityManager;
        }
        public Hotel Hotel { get; set; }
		
		public void OnGet(int id, string statusMessage)
        {
            HttpContext.Session.SetString("prev_page", "/HotelPages/HotelPage");
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
            StatusMessage = string.Empty;
            RoomReservationModel reservation = new RoomReservationModel();
			SearchModel searchModel = new SearchModel(); 
            int countOfRooms = 0;
            decimal totalPrice = 0;
            if(User.FindFirst("id") == null)
            {
                StatusMessage = "Log in to make reservation";
                return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
            }
            reservation.UserId = Convert.ToInt32(User.FindFirst("id").Value);
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
                reservation.StartDate = DateTime.Today;
                reservation.EndDate = DateTime.Today.AddDays(3);
            }
            else
            {
                reservation.StartDate = DateTime.ParseExact(searchModel.StartDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                reservation.EndDate = DateTime.ParseExact(searchModel.EndDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (searchModel.AmountOfGuests == null)
            {
                reservation.AmountOfGuest = 2;
            }
            else { reservation.AmountOfGuest = searchModel.AmountOfGuests.Value; }

            reservation.TotalPrice = totalPrice;
            reservation.ReservedRooms = ReservedRooms;
            HttpContext.Session.SetString("reservation", JsonConvert.SerializeObject(reservation));

            if(StatusMessage != string.Empty)
            {
                return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
            }
            
            return RedirectToPage("/HotelPages/Checkout");
        }
    }
}
