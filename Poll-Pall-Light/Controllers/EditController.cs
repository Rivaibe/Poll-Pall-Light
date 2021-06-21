using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using AItemAPI.Models;
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
        
        public async Task<IActionResult> EditQItem(int? id)
        {
            var qItem = await _qService.GetQItemByID(id);

            var pItem = await _pollService.GetPollById(qItem.PollID);

            var qItemList = await _qService.GetQItemsByPollId(qItem.PollID);

            var aItemList = new List<AItem>();

            var qItemVariableList = new List<PollVariables>();

            foreach (var q in qItemList){
                aItemList.AddRange(await _aService.GetAItemsByQId(q.ID));
                qItemVariableList.AddRange(await _pollService.GetPollVariablesByPollAndQId(qItem.PollID, q.ID));
            }

            var qItemEditViewModel = new QItemEditViewModel
            {
                AItems = aItemList,
                QItem = qItem,
                QCreateViewModel = new QCreateViewModel(),
                VariablesList = qItemVariableList,
                QItems = qItemList,
                PollTitle = pItem.Title,
                PollID = pItem.ID,
                PollVariables = await _pollService.GetSinglePollVariableByPollAndQId(qItem.PollID, qItem.ID)
            };
            
            return View(qItemEditViewModel);
        }
        
        public IActionResult EditAItem()
        {
            return null;
        }

        
        public async Task<IActionResult> UpdateQItem(QItemEditViewModel qItemEditViewModel, int id)
        {
            var qItem = await _qService.GetQItemByID(id);

            var currentPollVariableItem = await _pollService.GetSinglePollVariableByPollAndQId(qItem.PollID, qItem.ID);
            
            // TODO - update poll variable
            
            var newPollVariable = new PollVariables
            {
                ID = currentPollVariableItem.ID,
                PollId = currentPollVariableItem.PollId,
                QId = currentPollVariableItem.QId,
                Boolean = qItemEditViewModel.NewPollVariables.Boolean,
                Text = qItemEditViewModel.NewPollVariables.Text,
                Number = qItemEditViewModel.NewPollVariables.Number,
                QBool = qItemEditViewModel.QBool,
                QImage = qItemEditViewModel.QImage,
                QNumber = qItemEditViewModel.QNumber,
                QText = qItemEditViewModel.QText
            };
            
            if (qItemEditViewModel.Image is { Length: > 0 }){
                await using var fs1 = qItemEditViewModel.Image.OpenReadStream();
                await using var ms1 = new MemoryStream();
                await fs1.CopyToAsync(ms1);
                var p1 = ms1.ToArray();
                newPollVariable.Picture = p1;
            }               
            
            var pItem = await _pollService.GetPollById(qItem.PollID);               
            
            _pollService.UpdatePollVariableByPollIdAndQId(newPollVariable);

            var newQItem = new QItem
            {
                ID = id,
                Title = qItemEditViewModel.QCreateViewModel.Title,
                PollID = qItem.PollID,
                EndPoll = qItem.EndPoll
            };
            
            _qService.UpdateQItem(newQItem);
            
            return RedirectToAction("QView", "Create", new {pItem.ID}, null);
        }       
    }
}
