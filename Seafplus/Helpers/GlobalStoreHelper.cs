using System.Web;
using Seafplus.BusinessLogic;
using Seafplus.BusinessLogic.Services.Interfaces;

namespace Seafplus.Helpers
{
	public static class GlobalStoreHelper
	{
		private static IUserService _userService;

		public static void Initialize(IUserService userService)
		{
			_userService = userService;
		}

		public static void SetSession(string username)
		{
			var user = _userService.GetUser(username);
			HttpContext.Current.Session[Constants.SessionKeys.User] = user;
		}
	}
}