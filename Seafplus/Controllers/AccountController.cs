using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using OAuth2;
using OAuth2.Client;
using Seafplus.BusinessLogic;
using Seafplus.BusinessLogic.Services.Interfaces;
using Seafplus.BusinessLogic.UnitOfWork;
using Seafplus.Models;

namespace Seafplus.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IUserService _userService;
		private readonly AuthorizationRoot _authorizationRoot;
		private IUnitOfWork _unitOfWork;

		public AccountController(IUserService userService, AuthorizationRoot authorizationRoot, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_userService = userService;
			_authorizationRoot = authorizationRoot;
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			Session[Constants.SessionKeys.User] = null;

			return RedirectToAction("Index", "Home");
		}

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(UserViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var user = _userService.CheckLogin(model.Email, model.Password);
				if (user != null)
				{
					FormsAuthentication.SetAuthCookie(user.Email, false);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}

					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "The user name or password provided is incorrect.");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		public RedirectResult Login()
		{
			return new RedirectResult(GetClient().GetLoginLinkUri());
		}

		private IClient GetClient()
		{
			return _authorizationRoot.Clients.First(c => c.Name == "Google");
		}

		public ActionResult Auth()
		{
			var client = GetClient();
			var userInfo = client.GetUserInfo(Request.QueryString);
			if (userInfo == null)
			{
				return RedirectToAction("LogOn");
			}

			var user = _userService.CheckLogin(userInfo.Id);
			if (user == null)
			{
				user = _userService.CreateUser(userInfo);
				_unitOfWork.Commit();

			}
			
			FormsAuthentication.SetAuthCookie(user.Email, false);

			return RedirectToAction("Index", "Home");
		}
	}
}
