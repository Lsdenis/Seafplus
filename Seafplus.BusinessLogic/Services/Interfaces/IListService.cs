using System.Collections.Generic;
using Seafplus.BusinessLogic.DataModel;

namespace Seafplus.BusinessLogic.Services.Interfaces
{
	public interface IListService
	{
		IList<List> GetLists(int boardId);
	}
}
