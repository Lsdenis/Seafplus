using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Seafplus.Models
{
	public class RegisterUserViewModel
	{
		[Required]
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last name")]
		public string LastName { get; set; }

		[Required]
		public string Password { get; set; }

		[Compare("Password")]
		[DisplayName("Confirm password")]
		public string ConfirmPassword { get; set; }

		[Required]
		public string Email { get; set; }
	}
}