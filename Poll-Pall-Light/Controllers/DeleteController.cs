using System;
using System.Threading.Tasks;
using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
using PollAPI.Services;
using QItemAPI.Services;
using QnAAPI.Services;

namespace Poll_Pall_Light.Controllers 
{
    public class DeleteController : Controller 
    {

        private readonly IAService _aService;
        private readonly IQService _qService;
        private readonly IPollService _pollService;

        public DeleteController(IAService aService, IQService qService, IPollService pollService)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
        } 
            
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePItem(int? id)
        {
            _pollService.DeletePItem(id);

            var q = await _qService.GetQItemsByPollId(id);

            foreach (var n in q)
            {
                _aService.DeleteAItemsByQId(n.ID);
            }

            _qService.DeleteQItemsByPollId(id);
            
            return RedirectToAction("Index", "Create", null, null );
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteQItem(int? id)
        {
            var y = Convert.ToInt32(TempData["idCurrent"]);

            _qService.DeleteQItem(id);
            _aService.DeleteAItemsByQId(id);

            return RedirectToAction("QView", "Create", new {id = y}, null );
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteAItem(int? id)
        {
            var y = Convert.ToInt32(TempData["idCurrent"]);

            _aService.DeleteAItem(id);

            return RedirectToAction("AView", "Create", new {id = y}, null );
        }
               
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteQItemSolo(int? id)
        {
            _qService.DeleteQItem(id);

            return RedirectToAction("AllQs", "Delete", null, null );
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteAItemSolo(int? id)
        {
            _aService.DeleteAItem(id);

            return RedirectToAction("AllAs", "Delete", null, null );
        } 
        
        [HttpGet]
        public IActionResult DeleteShowDialog()
        {
            var qItemViewModel = new QItemViewModel();

            return PartialView("_QViewModal.cshtml", qItemViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AllQs()
        {
            var q = await _qService.GetQItems();

            return View(q);
        }
        
        [HttpGet]
        public async Task<IActionResult> AllAs()
        {
             var a = await _aService.GetAItems();
 
             return View(a);           
        }
    }
}
