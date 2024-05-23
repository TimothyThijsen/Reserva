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
        ReservationManager reservationManager = ReservationManagerFactory.GetReservationManager(ReservationType.RoomReservation);
        //DynamicRoomPricing dynamicRoomPricing = new DynamicRoomPricing();
        [BindProperty]
        public string StatusMessage { get; set; }
        [BindProperty]
        public List<ReservedRoom> ReservedRooms { get; set; } = new List<ReservedRoom>();

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
                if (HttpContext.Session.GetInt32("hotel_id") != id)
                {
                    HttpContext.Session.SetInt32("hotel_id", id);
                }
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
                if(Hotel.Rooms.Find(r => r.Id == rm.RoomId).GetAvailability(DateRange) - rm.Quantity < 0)
                {
                    StatusMessage = "Insufficient Rooms for Your Request. Please Choose a Lower Quantity";
                    return RedirectToPage("/HotelPages/HotelPage", new { statusMessage = StatusMessage });
                }
            }
            reservation.AmountOfGuest = searchModel.AmountOfGuests ?? 2;
            reservation.UserId = Convert.ToInt32(User.FindFirst("id").Value);
            reservation.StartDate = DateTime.ParseExact(searchModel.StartDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            reservation.EndDate = DateTime.ParseExact(searchModel.EndDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //servation.TotalPrice = 0;
            reservation.ReservedRooms = ReservedRooms;
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

            foreach (Room room in Hotel.Rooms)
            {
                room.Schedule.AddListOfReservations(reservationManager.GetAllReservationByRoomId(room.Id));
            }
            DateRange = new DateRange(searchModel.GetStartDate(), searchModel.GetEndDate());
        }
    }
}
