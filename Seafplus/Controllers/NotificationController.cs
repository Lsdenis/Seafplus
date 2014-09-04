using System.Web.Mvc;

namespace Seafplus.Controllers
{
	public class NotificationController : Controller
	{
		//
		// GET: /Notification/

		public ActionResult EmptyNotification()
		{
			return PartialView("EmptyNotification");
		}
	}
}
