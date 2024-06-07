using DomainLayer;
using DomainLayer.ServiceClasses;
using Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.Mapper;
using Newtonsoft.Json;
using System.Reflection;

namespace ReservaWebApplication.Pages.HotelPages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        ReservationManager reservationManager = ReservationManagerFactory.GetReservationManager(ReservationType.RoomReservation);
        HotelManager hotelManager;
        public Hotel hotel;
        [BindProperty]
        public string StatusMessage {  get; set; }
       
        public RoomReservation reservation {  get; set; }
        public decimal PriceExcl {  get; set; }
        public CheckoutModel(HotelManager hotelManager)
        {
            this.hotelManager = hotelManager;
        }
        public void OnGet(string? statusMessage)
        {
            if(statusMessage != null)
            {
                StatusMessage = statusMessage;
            }
			SetupReservation();
		}
        public IActionResult OnPost() 
        {
            StatusMessage = string.Empty;
			try
			{
				SetupReservation();
				reservationManager.CreateReservation(reservation);
            }catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
            if (StatusMessage != string.Empty)
            {
				return RedirectToPage("/HotelPages/Checkout", new {statusMessage = StatusMessage});
			}
            HttpContext.Session.Remove("hotel_id");
            return RedirectToPage("/index");
        }
        private void SetupReservation()
        {
			hotel = hotelManager.GetHotelById((int)HttpContext.Session.GetInt32("hotel_id"));
            RoomReservationModel roomReservationModel = JsonConvert.DeserializeObject<RoomReservationModel>(HttpContext.Session.GetString("reservation"));
            reservation = roomReservationModel.ToLogicLayer();
			PriceExcl = roomReservationModel.TotalPrice;
			reservation.TotalPrice = RoomPriceHelper.GetTotalPriceIncl(PriceExcl);
		}
    }
}
