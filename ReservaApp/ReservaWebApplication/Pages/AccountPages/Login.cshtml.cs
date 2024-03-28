using DomainLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Models;
using System.Security.Claims;
using DomainLayer.ServiceClasses;
using DataAccessLayer;

namespace ReservaWebApplication.Pages.AccountPages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials Credentials { get; set; }
        public string StatusMessage { get; set; }
		MemberManager memberManager = new MemberManager(new MemberDAL());
        public void OnGet(string? statusMessage)
        {
            if(statusMessage != null)
            {
				StatusMessage = statusMessage.Trim();
			}
        }
        public IActionResult OnPost()
        {
			Member member;
			;
			if(!ModelState.IsValid)
			{
				return Page();
			}
		
			try
			{
				member = memberManager.Login(Credentials.Email, Credentials.Password);
				ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(member);
				HttpContext.SignInAsync(claimsPrincipal).GetAwaiter().GetResult();
			}
			catch (SqlException)
			{
				StatusMessage = "Unable to reach database at this current moment, please try again later";
			}
			catch (Exception ex)
			{
				StatusMessage = ex.Message;
			}

			if (StatusMessage != null)
			{
				var routeValues = new Dictionary<string, string> { { "statusMessage", StatusMessage! }, { "email", Credentials.Email } };
				return RedirectToPage("Login", routeValues);
			}
			
			return RedirectToPage("/Index");

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
