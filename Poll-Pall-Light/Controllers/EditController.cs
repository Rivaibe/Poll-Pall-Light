using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AItemAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
using PollAPI.Models;
using PollAPI.Services;
using QItemAPI.Models;
using QItemAPI.Services;

namespace Poll_Pall_Light.Controllers 
{
    public class EditController : Controller 
    {
        private readonly IAService _aService;
        private readonly IQService _qService;
        private readonly IPollService _pollService; 
        
        public EditController(IAService aService, IQService qService, IPollService pollService, UserManager<ApplicationUser> manager)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
        }       
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EditP(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var p = new PItemEditViewModel
            {
                Polls = await _pollService.GetPollsByUserId(userId),
                Tap = await _pollService.GetPollById(id)
            };

            var q = new List<QItem>();
            
            foreach (var x in p.Polls)
            {
                q.AddRange(await _qService.GetQItemsByPollId(x.ID));
            }

            p.QItems = q;            
            
            return View(p);
        }
        public IActionResult EditQItem()
        {
            return null;
        }
        public IActionResult EditAItem()
        {
            return null;
        }
        public IActionResult UpdatePItem(PItemEditViewModel pItemEditViewModel)
        {
            var p = new Poll
            {
                UserId = pItemEditViewModel.UserId,
                ID = pItemEditViewModel.TapId,
                Title = pItemEditViewModel.PollTitle,
                Description = pItemEditViewModel.PollDescription,
                IsPrivate = pItemEditViewModel.IsPrivate
            };
            
            _pollService.UpdatePItem(p);
            
            return RedirectToAction("Index", "Create");
        }
    }
}
