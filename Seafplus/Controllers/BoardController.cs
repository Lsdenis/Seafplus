using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Services.Interfaces;
using Seafplus.BusinessLogic.UnitOfWork;
using Seafplus.Models;

namespace Seafplus.Controllers
{
    public class BoardController : BaseController
    {
		private readonly IBoardService _boardService;
	    private IUnitOfWork _unitOfWork;
	    private readonly IListService _listService;

	    public BoardController(IUnitOfWork unitOfWork, IBoardService boardService, IListService listService)
	    {
		    _listService = listService;
		    _unitOfWork = unitOfWork;
			_boardService = boardService;
	    }

		[HttpGet]
	    public JsonResult Boards()
	    {
		    var boards = _boardService.GetBoards(User.Identity.Name);
		    var boardsViewModel = Mapper.Map<IList<Board>, IList<BoardViewModel>>(boards);

		    return Json(new {success = true, data = boardsViewModel}, JsonRequestBehavior.AllowGet);
	    }

	    public ActionResult Index(int id)
	    {
		    var board = _boardService.GetBoard(id);
		    var boardViewModel = Mapper.Map<Board, BoardViewModel>(board);

		    var lists = _listService.GetLists(board.Id);
		    var listsViewModel = Mapper.Map<IList<List>, IList<ListViewModel>>(lists);

		    ViewBag.Lists = listsViewModel;
		    return View(boardViewModel);
	    }
    }
}
