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
		[Required]
		public string FirstName {  get; set; }
		[Required]
		public string LastName { get; set; }
		//[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Range(18, 100, ErrorMessage = "Must be 18+")]
		public int Age { get; set; }
		[Required]
		public MemberType Role { get; set; }

		[StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be longer than 6 characters.")]
		[RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "Password must contain at least one numeric digit.")]
		public string Password {  get; set; }
		public MemberModel() { }

	}
}
