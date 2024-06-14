using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReservaWebApplication.Pages.AccountPages
{
    [Authorize]


    public class AccountViewModel : PageModel
    {
        public Member Member { get; set; }
        public MemberManager MemberManager { get; set; }
        public AccountViewModel(MemberManager memberManager)
        {
            MemberManager = memberManager;
        }

        public void OnGet()
        {
            Member = MemberManager.GetMember(Convert.ToInt32(User.FindFirst("id").Value));
        }
    }
}
