using System;
using System.Collections.Generic;
using System.Linq;
using OAuth2.Models;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Enums;
using Seafplus.BusinessLogic.Helpers;
using Seafplus.BusinessLogic.Repository;
using Seafplus.BusinessLogic.Services.Interfaces;

namespace Seafplus.BusinessLogic.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _usersRepository;

		public UserService(IRepository<User> usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public List<User> GetAll()
		{
			return _usersRepository.GetAll().ToList();
		}

		public User GetUser(string username)
		{
			return _usersRepository.FirstOrDefault(user => user.Email == username);
		}

		public User CheckLogin(string email, string password)
		{
			var hash = AuthorizationHelper.GetHashString(password);
			var user = _usersRepository.FirstOrDefault(us => us.Email == email && us.Password == hash);
			return user;
		}

		public User CheckLogin(string googleId)
		{
			return _usersRepository.FirstOrDefault(user => user.GoogleId == googleId);
		}

		public User CreateUser(UserInfo userInfo)
		{
			var user = new User();
			user.GoogleId = userInfo.Id;
			user.LastName = userInfo.LastName;
			user.FirstName = userInfo.FirstName;
			user.UserRoleId = (int) UserRolesEnum.User;
			user.Email = userInfo.Email;
			_usersRepository.Add(user);
			return user;
		}
	}
}
