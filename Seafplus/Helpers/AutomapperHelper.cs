using AutoMapper;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.Models;

namespace Seafplus.Helpers
{
	public static class AutomapperHelper
	{
		public static void Init()
		{
			Mapper.CreateMap<User, UserViewModel>();
		}
	}
}