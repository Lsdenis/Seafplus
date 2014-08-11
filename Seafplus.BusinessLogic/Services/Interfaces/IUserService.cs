using System.Collections.Generic;
using OAuth2.Models;
using Seafplus.BusinessLogic.DataModel;

namespace Seafplus.BusinessLogic.Services.Interfaces
{
	public interface IUserService
	{
		List<User> GetAll();
		User GetUser(string username);
		User CheckLogin(string email, string password);
		User CheckLogin(string googleId);
		User CreateUser(UserInfo userInfo);
		bool AddUser(User user);
	}
}
