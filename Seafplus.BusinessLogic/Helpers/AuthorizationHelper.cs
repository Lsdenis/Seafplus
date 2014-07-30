using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Seafplus.BusinessLogic.Helpers
{
	public static class AuthorizationHelper
	{
		public static string GetHashString(string password)
		{
			var bytes = Encoding.Unicode.GetBytes(password);
			var csp = new MD5CryptoServiceProvider();
			var byteHash = csp.ComputeHash(bytes);

			return byteHash.Aggregate(string.Empty, (current, b) => current + string.Format("{0:x2}", b));
		}
	}
}
