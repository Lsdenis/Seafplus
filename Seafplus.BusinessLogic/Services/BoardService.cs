using System.Collections.Generic;
using System.Linq;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Repository;
using Seafplus.BusinessLogic.Services.Interfaces;

namespace Seafplus.BusinessLogic.Services
{
	public class BoardService : IBoardService
	{
		private readonly IRepository<UserBoard> _userBoardRepository;
		private readonly IRepository<User> _userRepository;
		private IRepository<Board> _boardRepository;

		public BoardService(IRepository<UserBoard> userBoardRepository, IRepository<User> userRepository, IRepository<Board> boardRepository)
		{
			_boardRepository = boardRepository;
			_userRepository = userRepository;
			_userBoardRepository = userBoardRepository;
		}

		public IList<Board> GetBoards(string username)
		{
			var user = _userRepository.FirstOrDefault(usr => usr.Email == username);
			var boards = _userBoardRepository.GetQueryable(board => board.UserId == user.Id);
			return boards.Select(board => board.Board).ToList();
		}

		public Board GetBoard(int id)
		{
			return _boardRepository.FirstOrDefault(board => board.Id == id);
		}
	}
}
