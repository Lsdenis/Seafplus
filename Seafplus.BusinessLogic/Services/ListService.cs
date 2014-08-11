using System.Collections.Generic;
using System.Linq;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Repository;
using Seafplus.BusinessLogic.Services.Interfaces;

namespace Seafplus.BusinessLogic.Services
{
	public class ListService : IListService
	{
		private readonly IRepository<List> _listRepository;

		public ListService(IRepository<List> listRepository)
		{
			_listRepository = listRepository;
		}

		public IList<List> GetLists(int boardId)
		{
			return _listRepository.GetQueryable(list => list.BoardId == boardId).ToList();
		}
	}
}
