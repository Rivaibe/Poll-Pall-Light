using Microsoft.AspNetCore.Mvc;
using Poll_Pall_Light.Models;
using Poll_Pall_Light.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Pall_Light.Controllers
{
    public class PollController : Controller
    {
        private readonly IPollService _service;
        public PollController(IPollService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {

            return View(_service.GetPolls());
        }
        public IActionResult Start(int id)
        {
            var startPoll = _service.GetPolls().FirstOrDefault(x => x.ID == id);
            return View(startPoll);
        }
    }
}
