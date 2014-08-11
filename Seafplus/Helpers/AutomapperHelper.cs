using System.Linq;
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
			Mapper.CreateMap<RegisterUserViewModel, User>();
			Mapper.CreateMap<Board, BoardViewModel>()
				.ForMember(model => model.Organization, expression => expression.MapFrom(board => board.Organization.Name));
			Mapper.CreateMap<List, ListViewModel>()
				.ForMember(model => model.Cards, expression => expression.MapFrom(list => list.Cards.Select(card => card.Name)));
		}
	}
}