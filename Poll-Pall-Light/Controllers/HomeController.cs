using AItemAPI.Models;
using AItemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poll_Pall_Light.Models;
using PollAPI.Services;
using QItemAPI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Poll_Pall_Light.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAService _service;
        private readonly IQService _service2;
        private readonly IPollService _service3;

        public HomeController(ILogger<HomeController> logger, IAService service, IQService service2, IPollService service3)
        {
            _logger = logger;
            _service = service;
            _service2 = service2;
            _service3 = service3;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Tutorial()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}