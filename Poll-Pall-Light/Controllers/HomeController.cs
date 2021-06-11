using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poll_Pall_Light.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AItemAPI.Models;


namespace Poll_Pall_Light.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAService _service;

        public HomeController(ILogger<HomeController> logger, IAService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {

            var x = _service.GetAItems();
            return View(x);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var a = new AItem();
            
            return View(a);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AItem aItem)
        {
            if (aItem == null)
                return NotFound();
            
            _service.AddAItem(aItem);
            
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var a = _service.GetAItemByID(id);
            if (a == null)
                return NotFound();
            
            return View(a);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
                return NotFound();
            
            _service.DeleteAItem(id);
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}