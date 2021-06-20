using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AItemAPI.Models;
using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
using PollAPI.Models;
using PollAPI.Services;
using QItemAPI.Models;
using QItemAPI.Services;

namespace Poll_Pall_Light.Controllers 
{
    public class UseController : Controller 
    {
        private readonly IAService _aService;
        private readonly IQService _qService;
        private readonly IPollService _pollService;

        private ResultViewModel _currentResults = new();

        public UseController(IAService aService, IQService qService, IPollService pollService)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
        }  
        
        public async Task<IActionResult> Index()
        {
            var p = await _pollService.GetPolls();
            
            return View(p);
        }
        
        public async Task<IActionResult> TakePoll(int? id)
        {
            // ViewData["userName"] = HttpContext.User.Identity?.Name;
            
            var p = new PItemUseModel
            {
                Poll = await _pollService.GetPollById(id),
                NextQId = 0,
                EndPoll = false
            };

            var q = await _qService.GetQItemsByPollId(id);

            var l = new List<AItem>();

            foreach (var x in q)
            {
                var a = await _aService.GetAItemsByQId(x.ID);
                l.AddRange(a);
            }
            
            p.QItems = q;
            p.AItems = l;

            return View(p); 
        }
        
        public async Task<IActionResult> NextQ(int? id)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var currentPId = Convert.ToInt32(TempData["itemPId"]);
            var currentQId = Convert.ToInt32(TempData["qId"]);
            
            var p = new PItemUseModel
            {
                Poll = await _pollService.GetPollById(currentPId),
                EndPoll = false
            };

            var q = await _qService.GetQItemsByPollId(currentPId);

            var l = new List<AItem>();

            foreach (var x in q)
            {
                var a = await _aService.GetAItemsByQId(x.ID);
                l.AddRange(a);
            }
            
            p.QItems = q;
            p.AItems = l; 
            
            var n = await _aService.GetAItemByID(id);
            
            foreach (var i in p.QItems.Where(i => i.ID == Convert.ToInt32(n.QID))){
                p.NextQId = i.ID;
            }

            if (n.QID == "0")
                p.EndPoll = true;

            var result = new PollResult
            {
                PollId = p.Poll.ID,
                QId = currentQId,
                AId = n.ID,
                UserId = userId,
                Date = DateTime.Now
            };

            var currentResult = new PollCurrentResult
            {
                PollId = p.Poll.ID,
                QId = currentQId,
                AId = n.ID,
                UserId = userId
            };
            
            _pollService.AddResultItem(result);
            
            return p.EndPoll == false ? View(p) : RedirectToAction("EndView");
        }

        public async Task<IActionResult> EndView()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _currentResults.CurrentResults = await _pollService.GetCurrentPollResultsByUserId(userId);

            foreach (var r in _currentResults.CurrentResults){
                var q = await _qService.GetQItemByID(r.QId);
                var a = await _aService.GetAItemByID(r.AId);
                if (a.isChecked == false){
                    _currentResults.Result.Add("Wrong");
                    _currentResults.QTitle.Add(q.Title);
                }
                else{
                    _currentResults.Result.Add("Right");
                    _currentResults.QTitle.Add(q.Title);
                }
            }

            var res = _currentResults;

            _currentResults = null;
            
            return View(res);
        }
        public IActionResult PrivatePolls()
        {
            return View();
        }
    }
}
