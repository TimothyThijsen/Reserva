
using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class MemberModel 
	{
		[Required(ErrorMessage = "First name is required")]
		public string FirstName {  get; set; }
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }
		//[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		//[Range(typeof(DateTime), "01/01/1900", "12/31/2099", ErrorMessage = "Date of birth must be between 1900 and 2099")]
		[Display(Name = "Date of Birth")]
		[Required(ErrorMessage = "Date of birth is required")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public MemberType Role { get; set; }

		[StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be longer than 6 characters.")]
		[RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "Password must contain at least one numeric digit.")]
		public string Password {  get; set; }
		public MemberModel() { }
        public MemberModel(string firstName, string lastName, string email, DateTime date, MemberType memberType, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = date;
            Role = memberType;
            Password = password;
        }

    }
}
