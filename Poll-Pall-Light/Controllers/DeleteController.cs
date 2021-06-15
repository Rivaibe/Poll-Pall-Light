using System;
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
        private readonly IQnAItemService _qnAItemService;

        public DeleteController(IAService aService, IQService qService, IPollService pollService, IQnAItemService qnAItemService)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
            _qnAItemService = qnAItemService;
        } 
            
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteQItem(int? id)
        {
            var y = Convert.ToInt32(TempData["idCurrent"]);

            _qService.DeleteQItem(id);

            return RedirectToAction("QView", "Create", new {id = y}, null );
        }
        
        [HttpGet]
        public IActionResult DeleteShowDialog()
        {
            var qItemViewModel = new QItemViewModel();

            return PartialView("_QViewModal.cshtml", qItemViewModel);
        }
    }
}
