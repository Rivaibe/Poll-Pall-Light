using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AItemAPI.Models;
using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
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
                Poll = await _pollService.GetPollById(id)
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
        public IActionResult NextQ(int? id)
        {
            return RedirectToAction("");
        }
    }
}
