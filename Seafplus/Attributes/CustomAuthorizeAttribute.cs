using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seafplus.BusinessLogic;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Enums;
using Seafplus.Helpers;

namespace Seafplus.Attributes
{
	public class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		public UserRolesEnum[] RequiredRoles { get; set; }

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (httpContext == null)
			{
				throw new ArgumentNullException("httpContext");
			}

			if (httpContext.User == null)
			{
				return false;
			}

			if (httpContext.Session == null || httpContext.Session[Constants.SessionKeys.User] as User == null)
			{
				GlobalStoreHelper.SetSession(httpContext.User.Identity.Name);
			}

			var user = httpContext.Session[Constants.SessionKeys.User] as User;

			return user != null && RequiredRoles.Contains((UserRolesEnum)user.UserRoleId);
		}
	}
}