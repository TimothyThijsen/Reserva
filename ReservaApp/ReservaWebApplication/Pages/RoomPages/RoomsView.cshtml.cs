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
        public List<Room> Rooms {  get; set; } = new List<Room>();
        public void OnGet()
        {
            Rooms = roomManager.GetAllRooms();
        }
    }
}
