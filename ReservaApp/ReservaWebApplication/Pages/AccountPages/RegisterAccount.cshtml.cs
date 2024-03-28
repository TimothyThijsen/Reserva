using DomainLayer.ServiceClasses;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Models.Mapper;

namespace ReservaWebApplication.Pages.AccountPages
{
    
    public class RegisterAccountModel : PageModel
    {
		[BindProperty]
		public MemberModel Member {  get; set; }
		public string StatusMessage { get; set; }
		MemberManager memberManager = new MemberManager(new MemberDAL());
		public void OnGet(string? statusMessage)
        {
			if (statusMessage != null)
			{
				StatusMessage = statusMessage.Trim();
			}
        }
        public IActionResult OnPost() 
        {
			if (!ModelState.IsValid)
			{
				return Page();
			}
			try
			{
				memberManager.AddMember(Member.ToLogicLayer());
			}
			catch (ValidationException ex)
			{
				StatusMessage = ex.Message;
			}
			catch (SqlException)
			{
				StatusMessage = "Unable to reach database at this current moment, please try again later";
			}catch(Exception ex)
			{
				StatusMessage = ex.Message;
			}

			if (StatusMessage != null)
			{
				return RedirectToPage("CreateAccountPage", new Dictionary<string, string> { { "statusMessage", StatusMessage } });
			}
			return new RedirectToPageResult("Index");

		}
	}
}
