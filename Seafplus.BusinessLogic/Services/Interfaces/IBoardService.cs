using System.Collections.Generic;
using Seafplus.BusinessLogic.DataModel;

namespace Seafplus.BusinessLogic.Services.Interfaces
{
	public interface IBoardService
	{
		IList<Board> GetBoards(string username);
		Board GetBoard(int id);
	}
}
