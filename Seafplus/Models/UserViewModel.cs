using System.ComponentModel.DataAnnotations;

namespace Seafplus.Models
{
	public class UserViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Email { get; set; }
	}
}