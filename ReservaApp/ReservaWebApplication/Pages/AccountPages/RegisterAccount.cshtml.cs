using DataAccessLayer;
using DomainLayer;
using DomainLayer.ServiceClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ReservaWebApplication.Pages.AccountPages
{

    public class RegisterAccountModel : PageModel
    {
        [BindProperty]
        public MemberModel Member { get; set; } = new MemberModel() { DateOfBirth = DateTime.Today.AddYears(-18) };
        public string? StatusMessage { get; set; }
        MemberManager memberManager = new MemberManager(new MemberDAL());
        public RegisterAccountModel(MemberManager memberManager) { this.memberManager = memberManager; }
        public void OnGet(string? statusMessage)
        {
            if (statusMessage != null)
            {
                StatusMessage = statusMessage.Trim();
            }
        }
        public IActionResult OnPost()
        {
            StatusMessage = string.Empty;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                memberManager.AddMember(Member);

            }
            catch (ValidationException ex)
            {
                StatusMessage = ex.Message;
            }
            catch (SqlException)
            {
                StatusMessage = "Unable to reach database at this current moment, please try again later";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            if (StatusMessage != string.Empty)
            {
                return RedirectToPage("/AccountPages/RegisterAccount", new Dictionary<string, string> { { "statusMessage", StatusMessage } });
            }
            try
            {
                Member member = memberManager.Login(Member.Email, Member.Password);
                ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(member);
                HttpContext.SignInAsync(claimsPrincipal).GetAwaiter().GetResult();
            }
            catch (Exception) { }
            return new RedirectToPageResult("/Index");

        }
        private ClaimsPrincipal GetClaimsPrincipal(Member member)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id", member.Id.ToString()));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
