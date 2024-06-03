using DataAccessLayer;
using DomainLayer;
using DomainLayer.Interfaces;
using DomainLayer.ServiceClasses;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace ReservaWebApplication.Pages.HotelPages
{
    public class HotelPageModel : PageModel
    {
        HotelManager hotelManager;
        public CityManager cityManager;
        public ReservationManager reservationManager = ReservationManagerFactory.GetReservationManager(ReservationType.RoomReservation);
        [BindProperty]
        public string StatusMessage { get; set; }
        [BindProperty]
        public List<ReservedRoom> ReservedRooms { get; set; } = new List<ReservedRoom>();
        public List<RoomDTO> roomDTOs { get; set; } = new List<RoomDTO>();
        public SearchModel searchModel = new SearchModel();
        public Hotel Hotel { get; set; }
        public DateRange DateRange { get; set; }
        public HotelPageModel(HotelManager hotelManager, CityManager cityManager) 
        { 
            this.hotelManager = hotelManager;
            this.cityManager = cityManager;
        }
		public void OnGet(int id, string statusMessage)
        {
            HttpContext.Session.SetString("prev_page", "/HotelPages/HotelPage");
            if (id> 0)
            {
                if (HttpContext.Session.GetInt32("hotel_id") != id){HttpContext.Session.SetInt32("hotel_id", id);}
            }
            Setup();
          
            foreach (Room room in Hotel.Rooms)
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
            RoomReservationModel reservation = new RoomReservationModel();
			 
            if(User.FindFirst("id") == null)
            {
                StatusMessage = "Log in to make reservation";
                return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
            }
            if (ReservedRooms.Sum(r => r.Quantity) < 1)
            {
                StatusMessage = "No room selected, please select a room to continue!";
                return RedirectToPage("/HotelPages/HotelPage", new {statusMessage = StatusMessage });
            }
            Setup();
            foreach (ReservedRoom rm in ReservedRooms)
            {
                if(reservationManager.GetAvailability(DateRange,rm.RoomId) - rm.Quantity < 0)
                {
                    StatusMessage = "Insufficient Rooms for Your Request. Please Choose a Lower Quantity";
                    return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
                }
                
            }
            reservation.AmountOfGuest = searchModel.AmountOfGuests ?? 2;
            reservation.UserId = Convert.ToInt32(User.FindFirst("id").Value);
            reservation.StartDate = searchModel.GetStartDate();
            reservation.EndDate = searchModel.GetEndDate();
            reservation.ReservedRooms = ReservedRooms;
            reservation.TotalPrice = (from room in roomDTOs
                                     join reserved in ReservedRooms on room.Id equals reserved.RoomId
                                     where reserved.Quantity > 0
                                     select room.Price * reserved.Quantity).Sum() * (DateRange.GetDaysCount() + 1);

            HttpContext.Session.SetString("reservation", JsonConvert.SerializeObject(reservation));

            return RedirectToPage("/HotelPages/Checkout");
        }
        private void Setup()
        {
            if (HttpContext.Session.GetString("search_model") != null)
            {
                searchModel = JsonConvert.DeserializeObject<SearchModel>(HttpContext.Session.GetString("search_model"));
            }
            searchModel.Setup();
            int id = (int)HttpContext.Session.GetInt32("hotel_id");
            Hotel = hotelManager.GetHotelAndRoomsById(id);
            DateRange = new DateRange(searchModel.GetStartDate(), searchModel.GetEndDate());
            roomDTOs = Hotel.GetRoomPrices(DateRange,reservationManager);
        }
    }
}
