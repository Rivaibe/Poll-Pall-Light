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
        public IActionResult Index()
        {
            var polls = _pollService.GetPolls();

            return View(polls);
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PollCreateViewModel pollCreateViewModel)
        {
            var q = new QItem()
            {
                Title = pollCreateViewModel.QItem.Title
            };
            _qService.AddAItem(q);
            
            var p = new Poll()
            {
                Title = pollCreateViewModel.Poll.Title,
                QRootID = q.ID

            };
            _pollService.AddAItem(p);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult CreateP()
        {
            var p = new PollCreateViewModel();
            
            return View(p);
        }
        
        [HttpGet]
        public IActionResult CreateQ()
        {
            var q = new QCreateViewModel();
            
            return View(q);
        }
        
        public IActionResult CreateQItem()
        {
            return null;
        }
        public IActionResult CreatePollView()
        {
            return null;
        }
    }
}
