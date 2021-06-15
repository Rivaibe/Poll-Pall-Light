using System;
using System.Threading.Tasks;
using AItemAPI.Models;
using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
using PollAPI.Models;
using PollAPI.Services;
using QItemAPI.Models;
using QItemAPI.Services;
using QnAAPI.Services;

namespace Poll_Pall_Light.Controllers 
{
    public class CreateController : Controller 
    {
        private readonly IAService _aService;
        private readonly IQService _qService;
        private readonly IPollService _pollService; 
        private readonly IQnAItemService _qnAItemService;

        public CreateController(IAService aService, IQService qService, IPollService pollService, IQnAItemService qnAItemService)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
            _qnAItemService = qnAItemService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var polls = await _pollService.GetPolls();

            return View(polls);
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreatePoll(PollCreateViewModel pollCreateViewModel)
        {
            var q = new QItem()
            {
                Title = pollCreateViewModel.QItem.Title
            };
            _qService.AddQItem(q);
            
            var p = new Poll()
            {
                Title = pollCreateViewModel.Poll.Title,
                QRootID = q.ID
            };
            _pollService.AddAItem(p);

            var x = await _pollService.GetPollByQRootId(p.QRootID);
            
            q.PollID = x.ID;
            _qService.UpdateQItem(q);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult CreatePollView()
        {
            var p = new PollCreateViewModel();
            
            return View(p);
        }

        public IActionResult CreateQItem(QItemViewModel qItemViewModel)
        {
            int x = Convert.ToInt32(TempData["idCurrent"]);
 
            var q = new QItem()
            {
                Title = qItemViewModel.QCreateViewModel.Title,
                PollID = x
            };
            _qService.AddQItem(q);
            return RedirectToAction("QView", new {id = q.PollID});
        }
        
        public async Task<IActionResult> QView(int? id)
        {
            var y = Convert.ToInt32(TempData["idCurrent"]);
            
            var p = await _pollService.GetPollById(y);

            var pnQ = new QItemViewModel()
            {
                QItems = await _qService.GetQItemsByPollId(y),
                PollTitle = p.Title,
                PollID = p.ID
            };

            ViewData["qCreate"] = new QCreateViewModel();
            ViewData["PollID"] = pnQ.PollID;

            return View(pnQ);
        }
    }
}
