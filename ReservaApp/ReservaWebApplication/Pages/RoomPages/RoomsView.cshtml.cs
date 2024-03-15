using DataAccessLayer;
using DomainLayer.ServiceClasses;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.RoomPages
{
    public class RoomsViewModel : PageModel
    {
        RoomManager roomManager = new RoomManager(new RoomDAL());
        [BindProperty]
        public List<Room> rooms {  get; set; } = new List<Room>();
        public void OnGet()
        {
            rooms = roomManager.GetAllRooms();
        }
    }
}
